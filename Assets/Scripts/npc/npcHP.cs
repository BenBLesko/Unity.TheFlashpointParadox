using System.Collections.Generic;
using UnityEngine;
using Abertay.Analytics;

// https://www.youtube.com/watch?v=sPiVz1k-fEs&list=PLPV2KyIb3jR6TFcFuzI2bB7TMNIIBpKMQ&index=9&ab_channel=Brackeys

public class npcHP : MonoBehaviour
{
    public Animator animator;

    public int maxNpcHP = 100; // maximum health points
    int currentNpcHP; // current health points

    public AudioSource sfx_impact; // source of audio
    public AudioSource sfx_die; // source of audio

    void Start()
    {
        currentNpcHP = maxNpcHP; // current health points equal to maximum health points at the start of the game
    }

    // to take damage
    public void takeDamage(int damage)
    {
        currentNpcHP -= damage;

        // to play damage animation
        animator.SetTrigger("takesDamage");

        // to play a sound
        sfx_impact.Play();

        if (currentNpcHP <= 0)
        {
            Die();

            // to play a sound
            sfx_die.Play();
        }
    }

    void Die()
    {
        // to play die animation
        animator.SetBool("isDead", true);

        // to disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        // send enemyDead Event
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            // { "isDead", true },
            { "levelName", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name }
        };
        AnalyticsManager.SendCustomEvent("enemyDead", parameters);
    }
}
