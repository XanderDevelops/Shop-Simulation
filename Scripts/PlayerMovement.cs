using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //This scipt is for the player movement, and was done during the interview test time

    public float speed = 5f;
    
    private Transform playerTransform;
    private Animator playerAnim;
    private SpriteRenderer playerSprite;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerAnim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical);
        playerTransform.position += movement * speed * Time.deltaTime;

        if (horizontal != 0 || vertical != 0)
        {
            playerAnim.SetBool("Moving", true);
                    
            if (horizontal < 0f && playerTransform.localScale.x > 0f)
            {
                playerTransform.localScale = new Vector3(-1f, playerTransform.localScale.y, playerTransform.localScale.z);
            }
            else if (horizontal > 0f && playerTransform.localScale.x < 0f)
            {
                playerTransform.localScale = new Vector3(1f, playerTransform.localScale.y, playerTransform.localScale.z);
            }
        }else{
            playerAnim.SetBool("Moving", false);
        }
    }
}
