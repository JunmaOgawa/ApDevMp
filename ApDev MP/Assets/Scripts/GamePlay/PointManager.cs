using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    int points;
    int choice;

    int tempHP;
    float tempATSPD;

    public GameObject UpgradeMenu;

    private void Awake()
    {
        points = PlayerPrefs.GetInt("Score");
    }
    public void AddBossPoints()
    {
        points += 30;
        UpgradeMenu.SetActive(true);
    }
    public void AddPoints()
    {
        points += 5;
    }

    public void Choice(int choosing)
    {
        choice = choosing;
    }

    public void NextSceneUpgrade(int choice)
    {
        switch(choice)
        {
            case 0:
                tempHP = PlayerPrefs.GetInt("HP");
                tempHP += 10;
                PlayerPrefs.SetInt("HP", tempHP);
                PlayerPrefs.SetInt("Score", points);
                break;
            case 1:
                tempATSPD = PlayerPrefs.GetFloat("AttackSpeed");
                tempATSPD += 0.5f;
                PlayerPrefs.SetFloat("AttackSpeed", tempATSPD);
                PlayerPrefs.SetInt("Score", points);
                break;
        }
    }
}
