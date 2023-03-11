using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=AD4JIXQDw0s&ab_channel=Brackeys

public class npcMovement : StateMachineBehaviour
{
    public Transform target; // position
    public float MoveSpeed = 0.75f; // value of the movement speed
    public float npcDistance = 2f; // value of the enemy's distance
    public float npcAttackRange = 0.5f; // the range of enemy's attack

    Transform playerCharacter; // position of the player
    Rigidbody2D rigidbody; // name of Rigidbody2D component
    npcFlip flip; // name of npcFlip

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player").transform; // playerCharacter is refering to the Player
        rigidbody = animator.GetComponent<Rigidbody2D>(); // rigidbody is refering to Rigidbody2D component
        flip = animator.GetComponent<npcFlip>(); // flip is refering to npcFlip.cs
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // when to flip the enemy's sprite
        flip.LookAtPlayer();

        // https://answers.unity.com/questions/607100/how-to-make-an-ai-to-follow-the-player-in-2d-c.html

        // the enemy's movement
        if (Vector3.Distance(playerCharacter.position, rigidbody.position) <= npcDistance)
        {
        Vector3 targetPlayer = new Vector3(playerCharacter.position.x, playerCharacter.position.y, rigidbody.position.y);
        Vector3 newPosition = Vector3.MoveTowards(rigidbody.position, targetPlayer, MoveSpeed * Time.fixedDeltaTime);
        rigidbody.MovePosition(newPosition);
        }

        // the enemy's attack
        if (Vector2.Distance(playerCharacter.position, rigidbody.position) <= npcAttackRange)
        {
            animator.SetTrigger("npcAttack");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // to reset the enemy's attack animation on Exit
        animator.ResetTrigger("npcAttack");
    }
}
