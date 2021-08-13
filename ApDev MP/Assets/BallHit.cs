using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Invoke("DeleteOnTime", 2f);

        if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("Death");
        }
        else if(collision.collider.tag == "Player" || collision.collider.tag == "Bullet")
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
