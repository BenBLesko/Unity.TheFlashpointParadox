using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// I was using playerHealthBar.cs as templates

public class bossHealthBar : MonoBehaviour
{
    public Slider bossSlider;

    public void SetMaxBossHealth(int bossHp)
    {
        bossSlider.maxValue = bossHp;
        bossSlider.value = bossHp;
    }

    public void SetBossHealth(int bossHp)
    {
        bossSlider.value = bossHp;
    }
}
