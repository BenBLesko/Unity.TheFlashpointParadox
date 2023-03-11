using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secretConversation : MonoBehaviour
{
    public GameObject isItA; // accessible GameObject
    public GameObject secretQuestion; // accessible GameObject

    void Start()
    {
        {
            StartCoroutine(secretCutscene()); // to start a coroutine
        }
    }
    IEnumerator secretCutscene()
    {
        yield return new WaitForSecondsRealtime(2); // to wait three seconds
        isItA.SetActive(true); // to set a gameobject active
        yield return new WaitForSecondsRealtime(4); // to wait three seconds

        isItA.SetActive(false); // to set a gameobject inactive
        secretQuestion.SetActive(true); // to set a gameobject active
    }
}
