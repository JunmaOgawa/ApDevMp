using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Player player;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = player.HP;
        slider.value = player.HP;
    }
    public void SetHealth(int health)
    {
        slider.value = player.HP;
    }
}
