using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I was using npcAttack as a template

public class bossAttack : MonoBehaviour
{
    public int bossNormalAttack = 20; // the damage value of the boss's attack
    public int bossLowHealthAttack = 30; // the damage value of the boss's attack at low health

    public Vector3 bossAttackOffset; // the point of the attack
    public float bossAttackRange = 0.3f; // the range of the attack
    public LayerMask bossAttackMask; // to detect the player

    public AudioSource sfx; // source of audio

    public void Attack()
    {
        // the position of the attack
        Vector3 pos = transform.position;
        pos += transform.right * bossAttackOffset.x;
        pos += transform.up * bossAttackOffset.y;

        // to detect the player
        Collider2D colInfo = Physics2D.OverlapCircle(pos, bossAttackRange, bossAttackMask);
        if (colInfo != null && colInfo.GetComponent<playerMovement>().canDodge == true)
        {
            // to deal damage
            colInfo.GetComponent<playerHP>().TakeDamage(bossNormalAttack);
            
            // to play a sound
            sfx.Play();
        }
    }

    public void LowHealthAttack()
    {
        // the position of the attack
        Vector3 pos = transform.position;
        pos += transform.right * bossAttackOffset.x;
        pos += transform.up * bossAttackOffset.y;

        // to detect the player
        Collider2D colInfo = Physics2D.OverlapCircle(pos, bossAttackRange, bossAttackMask);
        if (colInfo != null)
        {
            // to deal damage
            colInfo.GetComponent<playerHP>().TakeDamage(bossLowHealthAttack);
            
            // to play a sound
            sfx.Play();
        }
    }
}
