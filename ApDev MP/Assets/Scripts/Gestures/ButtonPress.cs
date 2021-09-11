using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    bool isFiring;
    GameObject player;

    public void pointerDown()
    {
        isFiring = true;
    }
    public void pointerUp()
    {
        isFiring = false;
    }

    private void Update()
    {
        if(isFiring) FindObjectOfType<ShootForward>().FireOn();
        else FindObjectOfType<ShootForward>().FireOff();
    }
}
