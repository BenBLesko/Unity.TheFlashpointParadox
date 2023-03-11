using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // namespace for UI

// https://www.youtube.com/watch?v=BLfNP4Sc_iA&ab_channel=Brackeys

public class playerHealthBar : MonoBehaviour
{
    // to set the health on the slider
    public Slider slider;

    public void SetMaxHealth(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
    }

    public void SetHealth(int hp)
    {
        slider.value = hp;
    }
}
