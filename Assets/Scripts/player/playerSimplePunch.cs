using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=sPiVz1k-fEs&list=PLPV2KyIb3jR6TFcFuzI2bB7TMNIIBpKMQ&index=9&ab_channel=Brackeys

public class playerSimplePunch : MonoBehaviour
{
    public Animator animator;

    public Transform punchPoint; // the point of attack
    public float punchRange = 0.08f; // the range of punch attack
    public int punchDamage = 20; // thedamage value of punch attack

    public float punchRate = 2f; // the rate of punch attack
    float nextPunch = 0f;

    public LayerMask enemyLayers; // to detect enemies

    // https://www.studytonight.com/game-development-in-2D/audio-in-unity
    // I'm using individual gameObjects to play multiple clips
    public AudioSource sfx; // source of audio

    void Update()
    {
        // which button triggers the punch attack
        if (Time.time >= nextPunch)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Attack());

                IEnumerator Attack()
                {
                    gameObject.GetComponent<playerMovement>().canMove = false;

                    SimplePunch();
                    nextPunch = Time.time + 1f / punchRate;

                    // to play a sound
                    sfx.Play();

                    yield return new WaitForSeconds(.25f);

                    gameObject.GetComponent<playerMovement>().canMove = true;
                }
            }
        }
    }

    void SimplePunch()
    {
    // to play the punch animation
    animator.SetTrigger("simplePunch");

    // to detect enemies
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(punchPoint.position, punchRange, enemyLayers);

    // to deal damage
    foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<npcHP>().takeDamage(punchDamage);
        }
    }
}
