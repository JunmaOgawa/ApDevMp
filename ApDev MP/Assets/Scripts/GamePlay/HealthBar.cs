using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Player player;
    public BossBehavior boss;
    public BossMan bossMan;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = player.HP;
        slider.value = player.HP;

        slider.maxValue = boss.health;
        slider.value = boss.health;

        slider.maxValue = boss.health;
        slider.value = bossMan.health;
    }
    public void SetHealth(int health)
    {
        slider.value = player.HP;
        slider.value = boss.health;
        slider.value = bossMan.health;
    }
}
