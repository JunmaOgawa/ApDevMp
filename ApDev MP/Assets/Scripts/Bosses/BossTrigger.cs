using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossHp;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            boss.SetActive(true);
            bossHp.SetActive(true);
            //Debug.Log("it works");
        }
    }
}
