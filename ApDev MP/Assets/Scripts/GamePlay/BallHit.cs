using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{



    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Invoke("DeleteOnTime", 2f);

        if (collision.collider.tag == "Enemy" || collision.collider.tag == "Player" || collision.collider.tag == "Bullet" || collision.collider.tag == "Shield")
        {
            
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void DeleteOnTime()
    {
        Destroy(this.gameObject);
        CancelInvoke();
    }
}
