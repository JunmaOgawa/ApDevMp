using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform.position + Camera.main.transform.rotation * Vector3.forward);
    }
}
