using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // namespace for UI

// I was using playerHealthBar.cs as a template

public class playerSpeedBar : MonoBehaviour
{
    // to set the speed on the slider
    public Slider slider;

    public void maxPlayerSP(int sp)
    {
        slider.maxValue = sp;
        slider.value = sp;
    }

    public void SetSpeed(int sp)
    {
        slider.value = sp;
    }


}
