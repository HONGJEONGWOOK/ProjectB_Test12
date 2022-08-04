﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))  //방향키 입력이 들어오면 실행
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1;
        Inputs();
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // 초기화 
    }

    void FixedUpdate()
    {
        Move();
    }
    void Inputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY); //되돌아가는

    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    private void OnCollisionEnter2D(Collision2D col)    //오브젝트 관련
    {
        if (col.gameObject.CompareTag("Rock"))
        {
            col.rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void OnCollisionExit2D(Collision2D other)   //오브젝트 관련
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            other.rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}