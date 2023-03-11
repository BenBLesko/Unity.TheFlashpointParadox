using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I haven't used tutorial for this script, I used playerSimpePunch.cs as a template

public class playerBossSimpleKick : MonoBehaviour
{
    public Animator animator;

    public Transform kickPoint; // the point of attack
    public float kickRange = 0.08f; // the range of kick attack
    public int kickDamage = 20; // the damage value of kick attack

    public float kickRate = 2f; // the rate of kick attack
    float nextKick = 0f;

    public LayerMask enemyLayers; // to detect enemies

    public AudioSource sfx; // source of audio

    void Update()
    {
        // which button triggers the kick attack
        if (Time.time >= nextKick)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                SimpleKick();
                nextKick = Time.time + 0.5f / kickRate;

                // to play a sound
                sfx.Play();
            }
        }
    }

    void SimpleKick()
    {
        // to play the kick animation
        animator.SetTrigger("simpleKick");

        // to detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(kickPoint.position, kickRange, enemyLayers);

        // to deal damage
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<bossHP>().takeDamage(kickDamage);
        }
    }
}
