using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://answers.unity.com/questions/1357145/local-high-score-with-game-over-scene.html
public class scoreTime_MainMenu : MonoBehaviour
{
    float playerTimeScoreMainMenu = 0; // the Score starts at 0
    public Text timescoreText; // accessible Text component

    void Update()
    {
        // the Score gets + 1 every seconds
        playerTimeScoreMainMenu += Time.fixedDeltaTime;
        timescoreText.text = "Time score:  " + Mathf.Floor((playerTimeScoreMainMenu + 1)).ToString();
    }

    public void increaseScore(int amount)
    {
        playerTimeScoreMainMenu += amount;
    }

    // to save the current value when a new scene is loaded
    void OnDestroy()
    {
        PlayerPrefs.SetInt("ScoreMainMenu", (int)(playerTimeScoreMainMenu + 1));
    }
}