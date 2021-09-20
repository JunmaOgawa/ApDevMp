using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossHealthBar : MonoBehaviour
{
    public Slider slider;
    public BossBehavior boss;
    /*public BossMan bossMan;*/
    public void SetMaxHealth(int health)
    {

        slider.maxValue = boss.health;
        slider.value = boss.health;

        /*slider.maxValue = bossMan.health;
        slider.value = bossMan.health;*/
    }
    public void SetHealth(int health)
    {
        slider.value = boss.health;
        /*slider.value = bossMan.health;*/
    }
}
