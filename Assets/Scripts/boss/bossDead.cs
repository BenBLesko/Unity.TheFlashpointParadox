using System.Collections.Generic;
using UnityEngine;
using Abertay.Analytics;

// I was using playerDead.cs as a template

public class bossDead : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("playerCharacter");

    }

    public void LoadNewScene()
    {
        // send gameCompleted Event
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "scoreCityStreets2", PlayerPrefs.GetInt("timeHighScore") },
            { "timePassedCityStreets2", Time.timeSinceLevelLoad },
            { "currentHealth", player.GetComponent<playerHP>().currentPlayerHP },
            { "currentSpeed", player.GetComponent<playerSpecialAttack>().currentPlayerSP }
        };
        AnalyticsManager.SendCustomEvent("gameCompleted", parameters);

        UnityEngine.SceneManagement.SceneManager.LoadScene("The-End");
    }
}