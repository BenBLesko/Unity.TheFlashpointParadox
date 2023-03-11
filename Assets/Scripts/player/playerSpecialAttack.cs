using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abertay.Analytics;

// I only used one tutorial for this script, otherwise it is showcasing what I have learned, up until that point, which is Week 6

public class playerSpecialAttack : MonoBehaviour
{
    public Animator animator;

    public Transform specialattackPoint; // the point of Special Attack
    public float specialattackRange = 0.08f; // the range of Special Attack
    public int specialattackDamage = 50; // the damage value of Special Attack

    public float specialattackRate = 2f; // the rate of punch attack
    float nextSpecialAttack = 0f;

    public LayerMask enemyLayers; // to detect enemies

    public int maxPlayerSP = 100; // maximum Speed Points
    public int minPlayerSP = 0; // minimum Speed Points
    public int marginPlayerSP = 19; // a margin for Speed Points is used to limit the numbers of Special Attack
    public int currentPlayerSP; // current Speed Points

    public playerSpeedBar speedBar; // the speed bar

    public AudioSource sfx; // source of audio

    void Start()
    {
        currentPlayerSP = 20; // the player starts with 20 Speed Points
        speedBar.SetSpeed(currentPlayerSP); // the speed bar is set to current Speed Points

        // https://answers.unity.com/questions/368113/regenerating-health-over-time.html

        StartCoroutine(addSpeedPoints());
    }

    void Update()
    {
        // which button triggers the Special Attack and how the limit works on it
        if (Time.time >= nextSpecialAttack)
        {
            if (currentPlayerSP < marginPlayerSP)
            {

            }
            else if (Input.GetButtonDown("Fire3"))
            {
                TakeSpeedDamage(20);
                SpecialAttack();
                nextSpecialAttack = Time.time + 1f / specialattackRate;

                // to play a sound
                sfx.Play();

                // send usedSpecialAttack Event
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    // { "isUsed", true },
                    { "currentSpeed", currentPlayerSP}
                };
                AnalyticsManager.SendCustomEvent("usedSpecialAttack", parameters);
            }
        }
    }

    void SpecialAttack()
    {
        // to play the Special Attack animation
        animator.SetTrigger("specialAttack");

        // to detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(specialattackPoint.position, specialattackRange, enemyLayers);

        // to deal damage
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<npcHP>().takeDamage(specialattackDamage);
        }
    }

    // every Special Attack costs 20 Speed Points
    void TakeSpeedDamage(int speedDamage)
    {
        currentPlayerSP -= speedDamage;
        speedBar.SetSpeed(currentPlayerSP);

        if (currentPlayerSP < minPlayerSP)
        {
            currentPlayerSP = 0;
            speedBar.SetSpeed(currentPlayerSP);
        }
    }

    // Speed Points are regenerating over time
    IEnumerator addSpeedPoints()
    {
        while (true) // a loop
        {
            if (currentPlayerSP < 100)
            {
                currentPlayerSP += 2; // to increase the Speed Points by 2
                yield return new WaitForSeconds(1); // to wait 1 second
                speedBar.SetSpeed(currentPlayerSP); // the speed bar is set to current Speed Points
            }
            else
            { 
                yield return null; // at 100 Speed Points, the regeneration turns off
            }
        }
    }
}
