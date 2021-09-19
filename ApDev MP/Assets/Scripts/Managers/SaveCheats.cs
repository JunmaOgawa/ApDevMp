using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveCheats : MonoBehaviour
{

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

    public void PlayButtonPressed(InputField name)
    {
        if(name.text != "") PlayerPrefs.SetString("Name", name.text); //sets name
        else PlayerPrefs.SetString("Name", "Player"); //if name is blank
        PlayerPrefs.SetInt("HP", 50); //set hp
        //D
        PlayerPrefs.SetInt("Sheilds", 2); // set shields
        PlayerPrefs.SetFloat("AttackSpeed", 1.0f); //set attackspeed
        PlayerPrefs.SetInt("Score", 0);

        //Debug.Log(PlayerPrefs.GetString("Name"));
        //Debug.Log(PlayerPrefs.GetInt("HP"));
        //Debug.Log(PlayerPrefs.GetFloat("AttackSpeed"));
        //Debug.Log(PlayerPrefs.GetInt("MaxAttackSpeed"));
        //Debug.Log(PlayerPrefs.GetInt("Invunerablility"));
    }
}
