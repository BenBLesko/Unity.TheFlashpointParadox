using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Abertay.Analytics;

// I was using healthPickUp.cs as a template

public class speedPowerUp : MonoBehaviour
{
    playerSpecialAttack playerSpecialAttack; // access the playerSpecialAttack.cs

    public int speedBoost = 20; // the speed power-up object worth 20 speed points

    public playerSpeedBar speedBar; // the speed bar

    public AudioSource sfx_pickup; // source of audio

    SpriteRenderer sprite; // to reference the Sprite Rendered
    BoxCollider2D col2D; // to reference the Box Collider 2D
    [SerializeField] Text text; // to reference the Win Condition Prompt Texts

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // to get the Sprite Renderer
        col2D = GetComponent<BoxCollider2D>(); // to get the Box Collider 2D
    }

    void Awake()
    {
        playerSpecialAttack = FindObjectOfType<playerSpecialAttack>(); // to get stuff from playerSpecialAttack.cs
    }

    // what happens when the player collide with the speed power-up object
    void OnTriggerEnter2D(Collider2D col)
    {
        if (playerSpecialAttack.currentPlayerSP < playerSpecialAttack.maxPlayerSP)
        {
            StartCoroutine(PickUpText());

            IEnumerator PickUpText()
            {
                // to show text and set gameObject invisible
                text.gameObject.SetActive(true);
                sprite.GetComponent<SpriteRenderer>().enabled = false;
                col2D.GetComponent<BoxCollider2D>().enabled = false;

                // to play a sound
                sfx_pickup.Play();

                // current speed points equals to current speed ponts plus the boost
                playerSpecialAttack.currentPlayerSP = playerSpecialAttack.currentPlayerSP + speedBoost;

                // to set the speed bar
                speedBar.SetSpeed(playerSpecialAttack.currentPlayerSP);

                // send speedPickUpped Event
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                // { "isSpeedPickedUp", true },
                { "currentSpeed", playerSpecialAttack.currentPlayerSP }
                };
                AnalyticsManager.SendCustomEvent("speedPickUpped", parameters);

                yield return new WaitForSeconds(3f);

                // to disable text
                text.gameObject.SetActive(false);

                yield return new WaitForSeconds(0.1f);

                // removes the speed power-up object
                Destroy(this.gameObject);
            }
        }
    }
}
