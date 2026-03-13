using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feet : MonoBehaviour
{
    public GameObject player;
    private float offset;
    private Movemen playerScript;
    private Transform playerTransform;

    void Start()
    {
        // Get the player script

        playerTransform = player.transform;
        playerScript = player.GetComponent<Movemen>();

        offset = -.6f;
    }

    void Update()
    {
        // Update the position of the feet to match the player's position
        transform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y+offset, playerTransform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            playerScript.SetGrounded(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            playerScript.SetGrounded(false);
            playerScript.SetAirJump(true);
        }
    }
}
