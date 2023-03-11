using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Abertay.Analytics;

public class lvl2Progression : MonoBehaviour
{

    public GameObject bg; // source of bg music
    public AudioSource stage_clear; // source of audio

    public GameObject stageclearUI; // to get access the Stage Clear UI!

    public GameObject player;

    void Start()
    {
        player = GameObject.Find("playerCharacter");

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // https://docs.unity3d.com/ScriptReference/WaitForSecondsRealtime.html
        StartCoroutine(Cutscene()); // to start a coroutine
    }
    IEnumerator Cutscene()
    {
        // to stop bg music
        bg.GetComponent<AudioSource>().Stop(); 
        stage_clear.Play();
        stageclearUI.SetActive(true);

        // send central-parkCompleted Event
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "scoreCentralPark", PlayerPrefs.GetInt("ScoreCentralPark") },
            { "timePassedCentralPark", Time.timeSinceLevelLoad },
            { "currentHealth", player.GetComponent<playerHP>().currentPlayerHP },
            { "currentSpeed", player.GetComponent<playerSpecialAttack>().currentPlayerSP }
        };
        AnalyticsManager.SendCustomEvent("central-parkCompleted", parameters);

        yield return new WaitForSecondsRealtime(3); // to wait three seconds

        stageclearUI.SetActive(false);

        // https://answers.unity.com/questions/1169114/how-to-load-next-scene-in-unity-5.html
        SceneManager.LoadScene("City-Streets-1"); // to load a new scene
    }
}
