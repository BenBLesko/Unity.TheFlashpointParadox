using System.Collections.Generic;
using UnityEngine;
using Abertay.Analytics;

// https://www.youtube.com/watch?v=L6Q6VHueWnU&ab_channel=KyleSuchar
// https://answers.unity.com/questions/356047/moving-player-up-and-down-in-2d.html
// https://answers.unity.com/questions/1564290/my-animation-is-overriding-my-character-movement.html

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 1f; // the value of the movement speed
    public bool canMove; // a bool that disables movement during attacks in attack scripts

    public float dodge = 0.3f; // the distance of dodge
    public float dodgeRate = 3f; // the rate of dodge
    float nextDodge = 0f;
    public bool canDodge;

    SpriteRenderer sprite; // to reference the Sprite Renderer

    // public float tapSpeed = 0.5f; // how much time a tap takes
    // private float lastTapTime = 0;

    void Start()
    {
        // lastTapTime = 0; // tap time starts at zero
        canMove = true;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (canMove == true)
        {
            Vector3 movementHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); // movements on X axes
            transform.position += movementHorizontal * moveSpeed * Time.deltaTime; // movement * speed * fixing

            Vector3 movementVertical = new Vector3(0f, Input.GetAxis("Vertical"), 0f); // movements on Y axes
            transform.position += movementVertical * moveSpeed * Time.deltaTime; // movement * speed * fixing
        }

        if (Time.time >= nextDodge)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(-Vector2.right * dodge);
                nextDodge = Time.time + 3f / dodgeRate;

                // send usedDodge Event
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                { "isDodgeUsed", true }
                };
                AnalyticsManager.SendCustomEvent("usedDodge", parameters);
            }
        }

        // to make the Player Character semi-transparent during Dodge
        if (Time.time >= nextDodge)
        {
            canDodge = true;
            sprite.color = new Color(1, 1, 1, 1);
        }
        else
        {
            canDodge = false;
            sprite.color = new Color(1, 1, 1, 0.5f);
        }

        // http://aidtech-game.com/double-tap-button-unity3d/#.X6btTWieSHu
        // if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        // {
        // if ((Time.time - lastTapTime) < tapSpeed)
        //{
        // moveSpeed = 4f; // the player runs faster

            // send usedDash Event
            // Dictionary<string, object> parameters = new Dictionary<string, object>()
            // {
            // { "isDashUsed", true }
            // };
            // AnalyticsManager.SendCustomEvent("usedDash", parameters);

            // }
            // else
            // moveSpeed = 2f;

            // lastTapTime = Time.time;
            // }
    }
}