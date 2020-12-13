using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playermove : MonoBehaviour//プレイヤースクリプト
{
    public readonly float SPEED = 0.05f;
    private Rigidbody2D rigidBody;
    private Vector2 input;
    public float stopf = 1;
    Animator animator;
    State state;

    public enum State
    {
        Normal,
        Talk,
        Command,
    }

    public void SetState(State state)
    {
        this.state = state;

        if (state == State.Normal)
        {
            stopf = 1;
            animator.enabled = true;
        }
        else if (state == State.Talk)
        {
            stopf = 0;
            animator.enabled = false;
        }
        else if (state == State.Command)
        {
            stopf = 0;
            animator.enabled = false;
        }
    }
    public State GetState()
    {
        return state;
    }

    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(stopf == 1){
            // 入力を取得
            input = new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"));
        }
    }

    private void FixedUpdate()
    {
        if (input == Vector2.zero)
        {
            return;
        }
        if (stopf == 1)
        {
            // 移動量を加算する
            rigidBody.position += input * SPEED;
        }
    }
}