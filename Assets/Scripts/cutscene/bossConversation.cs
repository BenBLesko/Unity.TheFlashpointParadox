using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Abertay.Analytics;

public class bossConversation : MonoBehaviour
{
    public GameObject ohBarry; // accessible GameObject
    public GameObject lookWhatYouDid; // accessible GameObject

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
        // https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html
        ohBarry.SetActive(true); // to set a gameobject active
        yield return new WaitForSecondsRealtime(3); // to wait three seconds
        
        ohBarry.SetActive(false); // to set a gameobject inactive
        lookWhatYouDid.SetActive(true); // to set a gameobject active

        // send city-streets-1Completed Event
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "scoreCityStreets1", PlayerPrefs.GetInt("ScoreCityStreets1") },
            { "timePassedCityStreets1", Time.timeSinceLevelLoad },
            { "currentHealth", player.GetComponent<playerHP>().currentPlayerHP },
            { "currentSpeed", player.GetComponent<playerSpecialAttack>().currentPlayerSP }
        };
        AnalyticsManager.SendCustomEvent("city-streets-1Completed", parameters);

        yield return new WaitForSecondsRealtime(3); // to wait three seconds

        // https://answers.unity.com/questions/1169114/how-to-load-next-scene-in-unity-5.html
        SceneManager.LoadScene("City-Streets-2"); // to load a new scene
    }
}
