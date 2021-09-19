using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManHealthBar : MonoBehaviour
{
    public Slider slider;
    public BossMan bossMan;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = bossMan.health;
        slider.value = bossMan.health;
    }
    public void SetHealth(int health)
    {
        slider.value = bossMan.health;
    }
}
