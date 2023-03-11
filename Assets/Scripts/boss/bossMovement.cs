using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I was using npcMovement.cs as a template

public class bossMovement : StateMachineBehaviour
{
    public Transform target; // position
    public float MoveSpeed = 1.2f; // value of the movement speed
    public float bossDistance = 2f; // value of the boss's distance
    public float bossAttackRange = 0.3f; // the range of boss's attack

    Transform playerCharacter; // position of the player
    Rigidbody2D boss_rigidbody; // name of Rigidbody2D component
    bossFlip flip; // name of bossFlip

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player").transform; // playerCharacter is refering to the Player
        boss_rigidbody = animator.GetComponent<Rigidbody2D>(); // rigidbody is refering to Rigidbody2D component
        flip = animator.GetComponent<bossFlip>(); // flip is refering to npcFlip.cs
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // when to flip the boss's sprite
        flip.LookAtPlayer();

        // the boss's movement
        if (Vector3.Distance(playerCharacter.position, boss_rigidbody.position) <= bossDistance)
        {
        Vector3 targetPlayer = new Vector3(playerCharacter.position.x, playerCharacter.position.y, boss_rigidbody.position.y);
        Vector3 newPosition = Vector3.MoveTowards(boss_rigidbody.position, targetPlayer, MoveSpeed * Time.fixedDeltaTime);
        boss_rigidbody.MovePosition(newPosition);
        }

        // the boss's attack with random animation
        if (Vector2.Distance(playerCharacter.position, boss_rigidbody.position) <= bossAttackRange)
        {
            animator.SetTrigger("bossAttack");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // to reset the boss's attack animation on Exit
        animator.ResetTrigger("bossAttack");
    }
}
