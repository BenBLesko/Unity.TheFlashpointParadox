using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initialTutorial : MonoBehaviour
{
    [SerializeField] Text tutorialPrompt; // to get access the Tutorial UI!
    [SerializeField] GameObject player; // to get access to the Player

    void Start()
    {
        tutorialPrompt.gameObject.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            tutorialPrompt.gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
