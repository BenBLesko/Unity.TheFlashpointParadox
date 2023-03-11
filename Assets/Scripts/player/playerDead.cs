using System.Collections.Generic;
using UnityEngine;
using Abertay.Analytics;

// https://answers.unity.com/questions/1467947/changing-the-scene-when-animation-ends.html
// how to load a new scene; it can be triggered via Animation Event

public class playerDead : MonoBehaviour
{
    public void LoadNewScene()
    {
        // send playerDead Event
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            // { "isDead", true },
            { "levelName", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name },
            { "playerLived", Time.timeSinceLevelLoad }
        };
        AnalyticsManager.SendCustomEvent("playerDead", parameters);

        UnityEngine.SceneManagement.SceneManager.LoadScene("Die");
    }
}