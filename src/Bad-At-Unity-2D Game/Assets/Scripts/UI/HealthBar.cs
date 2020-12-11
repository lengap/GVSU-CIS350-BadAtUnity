using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script handles health bar attributes (UI)
public class HealthBar : MonoBehaviour
{

    public Slider slider;

    //sets the UI health to the max level
    public void SetMaxHealth(int health)
    {
        slider.maxValue = 100;
        slider.value = health;
    }
    
    //sets UI health based on parameter
    public void SetHealth(int health)
    {
        slider.value = health;
    }

}
