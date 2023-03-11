using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// I was using playerHP.cs and playerHealthBar.cs as templates

public class bossHP : MonoBehaviour
{
    public Animator animator;

    public int maxBossHP = 300; // maximum health points
    int currentBossHP; // current health points
    public bossHealthBar bossHealthBar; // health bar

    public AudioSource sfx_impact; // source of audio
    public AudioSource sfx_die; // source of audio

    void Start()
    {
        currentBossHP = maxBossHP; // current health points equal to maximum health points at the start of the game
        bossHealthBar.SetMaxBossHealth(maxBossHP); // health bar is set to maximum
    }

    // to take damage
    public void takeDamage(int damage)
    {
        currentBossHP -= damage;
        bossHealthBar.SetBossHealth(currentBossHP);

        // to play damage animation
        animator.SetTrigger("takesDamage");

        // to play a sound
        sfx_impact.Play();

        if (currentBossHP <= 150)
        {
            GetComponent<Animator>().SetBool("isLowHealth", true);
        }

        if (currentBossHP <= 0)
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

        // to disable the boss
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
