using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    int points;

    private void Awake()
    {
        points = PlayerPrefs.GetInt("Score");
    }
    public void AddBossPoints()
    {
        points += 30;
    }
    public void AddPoints()
    {
        points += 5;
    }
}
