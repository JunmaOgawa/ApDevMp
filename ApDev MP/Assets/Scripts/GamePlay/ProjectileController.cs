using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float projectileSpeed = 50.0f;
    public Rigidbody rb;
    public Transform playerTF;
    public Rigidbody bullet;

    private void OnEnable()
    {
        if(rb != null)
        {
            rb.position = playerTF.position;
            rb.rotation = bullet.rotation;
            rb.velocity = Vector3.forward * projectileSpeed;
            //rb.AddForce(playerTF.forward * projectileSpeed, ForceMode.VelocityChange);
        }
        Invoke("Disable", 2f);
    }
    
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.position = playerTF.position;
        //rb.rotation = bullet.rotation;
        //rb.velocity = Vector3.forward * projectileSpeed;
        //rb.AddForce(playerTF.forward * projectileSpeed, ForceMode.VelocityChange);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
