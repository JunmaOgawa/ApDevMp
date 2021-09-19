using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForward : MonoBehaviour
{
    public Rigidbody bullet;
    public Rigidbody rBullet;
    public Rigidbody gBullet;
    public Rigidbody bBullet;
    public float velocity = 10.0f;
    public float fireCountDown = 0.0f;
    public float fireRate = .5f;
    bool firing = false;
    // Update is called once per frame

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

            if(fireCountDown >= 0)
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
        Rigidbody newBullet = Instantiate(bullet, transform.position, bullet.rotation) as Rigidbody;
        newBullet.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
        FindObjectOfType<AudioManager>().Play("Shoot");
    }
    public void FireOn()
    {
        firing = true;
    }
    public void FireOff()
    {
        firing = false;
    }
}