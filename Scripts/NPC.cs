using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //This scipt takes care of the behaviour of the the regular npc's/villagers, and was done during the interview test time

    private Transform playerTransform;
    private SpriteRenderer _spriteRenderer;
    
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(transform.position.x < playerTransform.position.x){
            _spriteRenderer.flipX = false;
        }
        else{
            _spriteRenderer.flipX = true;
        }
    }
}
