using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

// steps from idle animation to run animation
// http://johnstejskal.com/wp/creating-2d-animations-from-sprite-sheets-in-unity3d/
// https://answers.unity.com/questions/1564290/my-animation-is-overriding-my-character-movement.html

// to flip a sprite
// https://www.youtube.com/watch?v=y7IJsnKR120&ab_channel=PixelMake

public class playerAnimations : MonoBehaviour
{
    public Rigidbody2D rb; // name of the Rigidbody2D component
    public Animator animator; // name of the Animator component
    public float moveSpeed = 7f; // the vaule of the movement speed

    private float movementHorizontal;
    private float movementVertical;

    public bool facingR = true; // the player's sprite is facing Right

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // rb is refering to Rigidbody2D component
        animator = GetComponent<Animator>(); // animator is refering to Animator component
    }

    public void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementHorizontal, 0, movementVertical); // movements on X and Y axes
        rb.AddForce(movement * moveSpeed * Time.fixedDeltaTime); // movement * speed * fixing

        // when to flip the player's sprite
        if (movementHorizontal < 0 && facingR) Flip();
        if (movementHorizontal > 0 && !facingR) Flip();

        void Flip()
        {
            facingR = !facingR;
            transform.Rotate(Vector3.up * 180);
        }
    }

    public void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal"); // movementHorizontal is refering to horizontal axis
        movementVertical = Input.GetAxis("Vertical"); // movementVertical is refering to vertical axis

        // how the animations are changing from idle to run by input
        if (movementVertical > 0 || movementHorizontal > 0 || movementVertical < 0 || movementHorizontal < 0)
        {
            animator.SetBool("runRun", true);
        }
        else
        {
            animator.SetBool("runRun", false);
        }
    }
}