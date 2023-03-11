using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// I was using scoreTime_CityStreets1 as a template
public class scoreTime_CityStreets2 : MonoBehaviour
{
    scoreTime_CityStreets1 citystreets1Score;
    float playerTimeScoreCityStreets2 = 0;
    public Text timescoreText;

    void Start()
    {
        playerTimeScoreCityStreets2 = PlayerPrefs.GetInt("ScoreCityStreets1");
    }

    void Update()
    {
        playerTimeScoreCityStreets2 += Time.fixedDeltaTime;
        timescoreText.text = "Time score:  " + Mathf.Floor((playerTimeScoreCityStreets2 + 1)).ToString();
    }

    public void increaseScore(int amount)
    {
        playerTimeScoreCityStreets2 += amount;
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("ScoreCityStreets2", (int)(playerTimeScoreCityStreets2 + 1));

        int highScore = PlayerPrefs.GetInt("timeHighScore");
        int currentScore = (int)playerTimeScoreCityStreets2;

        // to save the lowest value individually when a new scene is loaded
        if (highScore >= currentScore || highScore == 0) 
        {
            PlayerPrefs.SetInt("timeHighScore", currentScore);
        }

        PlayerPrefs.Save();
    }
}