using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Abertay.Analytics;

// https://www.youtube.com/watch?v=TQhzBAKaOTE&ab_channel=ThinkBotLabs

public class healthPickUp : MonoBehaviour
{
    playerHP playerHP; // access the playerHP.cs

    public int healthBoost = 20; // the heart object worth 20 health points

    public playerHealthBar healthBar; // the health bar

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
        playerHP = FindObjectOfType<playerHP>(); // to get stuff from playerHP.cs
    }

    // what happens when the player collide with the heart object
    void OnTriggerEnter2D(Collider2D col)
    {
        if (playerHP.currentPlayerHP < playerHP.maxPlayerHP)
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

                // current health equals to current health plus the boost
                playerHP.currentPlayerHP = playerHP.currentPlayerHP + healthBoost;

                // to set the health bar
                healthBar.SetHealth(playerHP.currentPlayerHP);

                // send healthPickUp Event
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                // { "isHealthPickedUpped", true },
                { "currentHealth", playerHP.currentPlayerHP}
                };
                AnalyticsManager.SendCustomEvent("healthPickUpped", parameters);

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
