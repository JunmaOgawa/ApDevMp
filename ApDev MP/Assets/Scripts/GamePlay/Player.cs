using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private Transform playerModel;

    [Space]

    [Header("Parameters")]
    public float xySpeed = 18;
    public float lookSpeed = 340;
    public float forwardSpeed = 6;

    [Space]

    [Header("Public References")]
    public Transform aimTarget;
    public CinemachineDollyCart dolly;
    public Transform cameraParent;

    [Space]

    [Header("Public References")]
    public JoyStick joystick;

    [Space]

    [Header("HP And Name")]
    public int HP;
    public string Name;
    public HealthBar healthbar;

    public GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerModel = transform.GetChild(0);
        SetSpeed(forwardSpeed);
        HP = PlayerPrefs.GetInt("HP");
        Name = PlayerPrefs.GetString("Name");

        healthbar.SetMaxHealth(HP);
    }

    // Update is called once per frame
    void Update()
    {
        float h = joystick.JoystickAxis.x ;
        float v = joystick.JoystickAxis.y ;

        //transform.rotation.eulerAngles = new Vector3(0,0,-90 * Input.GetAxis("Barrel Roll"));

        LocalMove(h, v, xySpeed);
        RotationLook(h, v, lookSpeed);
        HorizontalLean(playerModel, h, 80, .1f);

        healthbar.SetHealth(HP);

        if (HP <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Death");
            GameOver.SetActive(true);
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.collider.tag == "EnemyBullet")
        {
            GotHit();
            FindObjectOfType<AudioManager>().Play("Hit");
            Destroy(collision.gameObject);
        }
        
    }

        void LocalMove(float x, float y, float speed)
    {
        transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
        ClampPosition();
    }
    void ClampPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void RotationLook(float h, float v, float speed)
    {
        aimTarget.parent.position = Vector3.zero;
        aimTarget.localPosition = new Vector3(h, v, 1);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * speed * Time.deltaTime);
    }

    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngels = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z, -axis * leanLimit, lerpTime));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(aimTarget.position, .5f);
        Gizmos.DrawSphere(aimTarget.position, .15f);
    }

    void SetSpeed(float x)
    {
        dolly.m_Speed = x;
    }

    public void QuickSpin(int dir)
    {
        if (!DOTween.IsTweening(playerModel))
        {
            playerModel.DOLocalRotate(new Vector3(playerModel.localEulerAngles.x, playerModel.localEulerAngles.y, 360 * -dir), .4f, RotateMode.LocalAxisAdd).SetEase(Ease.OutSine);
        }
    }

    public void GotHit()
    {
        HP--;
        healthbar.SetHealth(HP);
    }
}
