using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://answers.unity.com/questions/1357145/local-high-score-with-game-over-scene.html
public class leaderBoard : MonoBehaviour
{
    int timeScore = 0; // Score int
    int timeHighScore = 0; // HighScore int
    public Text timeScoreText; // accessible Text component for Score
    public Text timeHighScoreText; // accessible Text component for HighScore

    void Update()
    {
        timeScore = PlayerPrefs.GetInt("ScoreCityStreets2"); // timeScore is the stored "ScoreCityStreets2" value
        timeScoreText.text = "Time:  " + timeScore.ToString() + " seconds"; // to print "Time: (ScoreCityStreets2 value) seconds"
        
        timeHighScore = PlayerPrefs.GetInt("timeHighScore"); // timeScore is the stored "timeHighScore" value
        timeHighScoreText.text = "Fastest:  " + timeHighScore.ToString() + " seconds"; // to print "Time: (timeHighScore value) seconds"
    }
}