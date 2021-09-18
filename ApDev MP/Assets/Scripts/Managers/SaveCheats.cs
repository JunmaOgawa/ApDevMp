using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveCheats : MonoBehaviour
{
    public Toggle maxAttackSpeed;
    public Toggle invunerability;

    public void SetAttackSpeedValue(bool value)
    {
        if (value) 
        {
            PlayerPrefs.SetInt("MaxAttackSpeed", 1);
            //Debug.Log("MaxAttackSpeed is True");
        }
        else
        {
            PlayerPrefs.SetInt("MaxAttackSpeed", 0);
            //Debug.Log("MaxAttackSpeed is False");
        }
    }
    public void SetInvunerabilityValue(bool value)
    {
        if (value) PlayerPrefs.SetInt("Invunerability", 1);
        else PlayerPrefs.SetInt("Invunerability", 0);
    }
}
