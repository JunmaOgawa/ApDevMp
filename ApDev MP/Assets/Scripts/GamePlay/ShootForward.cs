using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForward : MonoBehaviour
{

    public Rigidbody rBullet;
    public Rigidbody gBullet;
    public Rigidbody bBullet;
    public float velocity = 10.0f;
    public float fireCountDown = 0.0f;
    public float fireRate = .5f;
    bool firing = false;
    // Update is called once per frame
    public Transform playerTransform;

    public int bulletType = 0;
    Rigidbody newBullet;
    //Rigidbody bullet = rBullet;

    public ImageHandler colorCornerUI;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("MaxAttackSpeed") == 1)
        {
            fireRate = 0.4f;//2.5 AttackSpeed
            //Debug.Log(PlayerPrefs.GetInt("MaxAttackSpeed"));
        }
        else fireRate = PlayerPrefs.GetFloat("AttackSpeed");
        Debug.Log(fireRate);
    }

    private void FixedUpdate()
    {
        /* if (fireCountDown <= 0)
         {
             Fire();
             fireCountDown = 1f / fireRate;
         }
         fireCountDown -= Time.deltaTime;*/

        if (fireCountDown >= 0)
        {
            fireCountDown -= Time.deltaTime;
        }
        else
        {
            fireCountDown += fireRate;
            if (Input.GetKey(KeyCode.Space))
            {
                Fire();
            }
            else if (firing)
            {
                Fire();
            }
        }
    }

    public void Fire()
    {
        switch (bulletType)
        {
            case 0:
                newBullet = Instantiate(rBullet, playerTransform.position, rBullet.rotation) as Rigidbody;
                newBullet.AddForce(playerTransform.forward * velocity, ForceMode.VelocityChange);
                FindObjectOfType<AudioManager>().Play("Shoot");
                Debug.Log("red");
                break;
            case 1:
                newBullet = Instantiate(gBullet, playerTransform.position, gBullet.rotation) as Rigidbody;
                newBullet.AddForce(playerTransform.forward * velocity, ForceMode.VelocityChange);
                FindObjectOfType<AudioManager>().Play("Shoot");
                Debug.Log("green");
                break;
            case 2:
                newBullet = Instantiate(bBullet, playerTransform.position, bBullet.rotation) as Rigidbody;
                newBullet.AddForce(playerTransform.forward * velocity, ForceMode.VelocityChange);
                FindObjectOfType<AudioManager>().Play("Shoot");
                Debug.Log("blue");
                break;
        }
    }
    public void FireOn()
    {
        firing = true;
    }
    public void FireOff()
    {
        firing = false;
    }

    public void ChangeBulletType (int bulletNum){
        bulletType = bulletType + bulletNum % 3;
        if (bulletType == -1) bulletType = 2;
        colorCornerUI.ChangeColor(bulletType);
    }
}