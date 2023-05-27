using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Transform playerTransform;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
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
