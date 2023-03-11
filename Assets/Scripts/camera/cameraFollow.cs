using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

// https://answers.unity.com/questions/878913/how-to-get-camera-to-follow-player-2d.html
// I use Cinemachine in the project, but I still wanted to show that I was researching alternative methods

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        // the camera follows the player on X axis
        transform.position = new Vector3(player.position.x + 10, 3, -10);
    }
}
