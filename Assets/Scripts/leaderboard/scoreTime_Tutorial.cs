using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// I was using scoreTime_MainMenu as a template
public class scoreTime_Tutorial : MonoBehaviour
{
    scoreTime_MainMenu mainmenuScore; // access to scoreTime_MainMenu.cs
    float playerTimeScoreTutorial = 0;
    public Text timescoreText;

    void Start()
    {
        playerTimeScoreTutorial = PlayerPrefs.GetInt("ScoreMainMenu"); // to get the value from the previous into a new float
    }

    void Update()
    {
        playerTimeScoreTutorial += Time.fixedDeltaTime;
        timescoreText.text = "Time score:  " + Mathf.Floor((playerTimeScoreTutorial + 1)).ToString();
    }

    public void increaseScore(int amount)
    {
        playerTimeScoreTutorial += amount;
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("ScoreTutorial", (int)(playerTimeScoreTutorial + 1));
    }
}