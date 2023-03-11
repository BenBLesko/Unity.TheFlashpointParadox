using System.Collections.Generic;
using UnityEngine;
using Abertay.Analytics;

// https://www.youtube.com/watch?v=JivuXdrIHK0&ab_channel=Brackeys

public class pauseMenu : MonoBehaviour
{
    public static bool isPaused = false; // the game is not paused on default

    public GameObject pauseMenuUI; // to get access the Menu UI
    public GameObject controlsMenuUI; // to get access the Controls UI

    public GameObject player;

    void Start()
    {
        player = GameObject.Find("playerCharacter");

    }

    void Update()
    {
        // Escape pauses the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        // R resumes the game when it is paused
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isPaused)
            {
                Resume();
            }
        }

        // Q quits the game when it is paused
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isPaused)
            {
                // send playerQuit Event
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "timePassedQuit", Time.timeSinceLevelLoad },
                    { "currentHealth", player.GetComponent<playerHP>().currentPlayerHP },
                    { "currentSpeed", player.GetComponent<playerSpecialAttack>().currentPlayerSP }
                };
                AnalyticsManager.SendCustomEvent("playerQuit", parameters);

                Application.Quit();
            }
        }

        // C brings up the controls UI
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isPaused)
            {
                ControlsOn();
            }
        }

        // Backspace brings back the pause menu UI
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (isPaused)
            {
                ControlsOff();
            }
        }

        // what happens when the player resumes the game
        void Resume()
        {
            pauseMenuUI.SetActive(false);
            controlsMenuUI.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

        // what happens when the player pauses the game
        void Pause()
        {
            pauseMenuUI.SetActive(true);
            controlsMenuUI.SetActive(false);
            Time.timeScale = 0f;
            isPaused = true;
        }

        // what happens when the player enters the controls option
        void ControlsOn()
        {
            pauseMenuUI.SetActive(false);
            controlsMenuUI.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }

        // what happens when the player exits the controls option
        void ControlsOff()
        {
            controlsMenuUI.SetActive(false);
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }
}
