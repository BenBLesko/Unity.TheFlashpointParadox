using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// I was using scoreTime_MainMenu as a template
public class scoreTime_CentralPark : MonoBehaviour
{
    scoreTime_Tutorial tutorialScore;
    float playerTimeScoreCentralPark = 0;
    public Text timescoreText;

    void Start()
    {
        playerTimeScoreCentralPark = PlayerPrefs.GetInt("ScoreTutorial"); // to get the value from the previous into a new float
    }

    void Update()
    {
        playerTimeScoreCentralPark += Time.fixedDeltaTime;
        timescoreText.text = "Time score:  " + Mathf.Floor((playerTimeScoreCentralPark + 1)).ToString();
    }

    public void increaseScore(int amount)
    {
        playerTimeScoreCentralPark += amount;
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("ScoreCentralPark", (int)(playerTimeScoreCentralPark + 1));
    }
}