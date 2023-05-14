using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostBarController : MonoBehaviour
{
    public Slider slider;

    public Image fill;

    public void SetMaxBoost(int health)
    {
        if (slider != null)
        {
            slider.maxValue = health;
            slider.value = health;
        }
    }

    public void SetBoost(int health)
    {
        if (slider != null)
        {
            slider.value = health;

        }
    }
}
