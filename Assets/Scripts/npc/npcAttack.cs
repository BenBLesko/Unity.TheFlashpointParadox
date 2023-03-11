using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=AD4JIXQDw0s&ab_channel=Brackeys

public class npcAttack : MonoBehaviour
{
    public int npcSimpleAttack = 10; // the damage value of the enemy's attack

    public Vector3 npcAttackOffset; // the point of the attack
    public float npcAttackRange = 0.5f; // the range of the attack
    public LayerMask npcAttackMask; // to detect the player

    public AudioSource sfx; // source of audio

    public void Attack()
    {
        // the position of the attack
        Vector3 pos = transform.position;
        pos += transform.right * npcAttackOffset.x;
        pos += transform.up * npcAttackOffset.y;

        // to detect the player
        Collider2D colInfo = Physics2D.OverlapCircle(pos, npcAttackRange, npcAttackMask);
        if (colInfo != null && colInfo.GetComponent<playerMovement>().canDodge == true)
        {
            // to deal damage
            colInfo.GetComponent<playerHP>().TakeDamage(npcSimpleAttack);
            
            // to play a sound
            sfx.Play();
        }
    }
}
