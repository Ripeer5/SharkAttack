using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Image fill;

    public void SetMaxHealth(int health)
    {
        if (slider != null)
        {
            slider.maxValue = health;
        }
    }

    public void SetHealth(int health)
    {
        if (slider != null) {
            slider.value = health;

        }
    }
}
