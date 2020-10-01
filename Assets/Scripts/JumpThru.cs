using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThru : MonoBehaviour
{

    public float waitTime;
    private float waitTimeCounter;
    private PlatformEffector2D effector;
    private PlayerController player;
    private bool playerInCollision = false;
    

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.instance;
        effector = GetComponent<PlatformEffector2D>();
        waitTimeCounter = waitTime;
    }

    private void Update()
    {

        //if (!playerInCollision) return;

        // Check if the player is on top of this platform and is trying to move down from it.
        //if (player.GetMoveInput().y == 0)
        //{
        //    waitTimeCounter = waitTime;
        //}

        if (player.GetMoveInput().y < 0)
        {
            if (waitTimeCounter <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTimeCounter = waitTime;
            }
            else
            {
                waitTimeCounter -= Time.fixedDeltaTime;
            }
        }

        // Check if this player is below this platform and is trying to move onto it.
        if (player.GetMoveVelocity().y > 0 || player.isJumping)
        {
            effector.rotationalOffset = 0;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInCollision = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInCollision = false;
        }
    }
}
