
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // namespace for Unity Scene Management

// https://www.youtube.com/watch?v=BLfNP4Sc_iA&ab_channel=Brackeys

public class playerHP : MonoBehaviour
{
    public Animator animator;

    public int maxPlayerHP = 100; // maxium health points
    public int currentPlayerHP; // current health points
    public playerHealthBar healthBar; // health bar

    public AudioSource sfx_impact; // source of audio
    public AudioSource sfx_die; // source of audio

    void Start()
    {
        currentPlayerHP = maxPlayerHP; // current health points equal to maximum health points at the start of the game
        healthBar.SetMaxHealth(maxPlayerHP); // health bar is set to maximum
    }

    void Update()
    {

    }

    // to take damage
    public void TakeDamage(int damage)
    {
        currentPlayerHP -= damage;
        healthBar.SetHealth(currentPlayerHP);

        animator.SetTrigger("takesDamage");

        // to play a sound
        sfx_impact.Play();

        if (currentPlayerHP <= 0)
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

        // to disable the player
        GetComponent<Collider2D>().enabled = false;
        GetComponent<playerMovement>().enabled = false;
        GetComponent<playerAnimations>().enabled = false;
        
        GetComponent<playerSimpleKick>().enabled = false;
        GetComponent<playerSimplePunch>().enabled = false;
        GetComponent<playerSpecialAttack>().enabled = false;

        GetComponent<playerBossSimpleKick>().enabled = false;
        GetComponent<playerBossSimplePunch>().enabled = false;
        GetComponent<playerBossSpecialAttack>().enabled = false;
    }
}
