using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// I was using scoreTime_MainMenu as a template
public class scoreTime_CityStreets1 : MonoBehaviour
{
    scoreTime_CentralPark centralparkScore;
    float playerTimeScoreCityStreets1 = 0;
    public Text timescoreText;

    void Start()
    {
        playerTimeScoreCityStreets1 = PlayerPrefs.GetInt("ScoreCentralPark"); // to get the value from the previous into a new float
    }

    void Update()
    {
        playerTimeScoreCityStreets1 += Time.fixedDeltaTime;
        timescoreText.text = "Time score:  " + Mathf.Floor((playerTimeScoreCityStreets1 + 1)).ToString();
    }

    public void increaseScore(int amount)
    {
        playerTimeScoreCityStreets1 += amount;
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("ScoreCityStreets1", (int)(playerTimeScoreCityStreets1 + 1));
    }
}