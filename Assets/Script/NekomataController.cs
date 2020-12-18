using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Fungus;

public class NekomataController : MonoBehaviour
{
    //キャラの移動速度変更用
    public float speed = 3.0f;

    //宣言
    Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;

    public Animator animator;
    public Vector2 lookDirection = new Vector2(0,-1);
    Vector2 move;

    //会話用
    public Flowchart flowchart1;
    public Flowchart flowchart2;

    //開始関数(update関数の前に1度だけ呼び出される)
    void Start()
    {
        // ↓どのスペックでも同じになるようにゲームの速度を制御(現在は必要ない)
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10; // 10フレーム/1sに設定し直す

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //更新関数(フレーム毎に呼び出される)
    void Update()
    {
        /*
        Vector2: 2Dなので2つの数値を格納する変数を使用。「x位置とy位置」用
        transform: Unity内、Rubyの位置や角度、大きさを設定する場所。
        transform.position: Unity内、Rubyの位置（表示する座標）を設定する場所。
        */
        /*
        Vector2 position = transform.position; //「取得」：UnityのTransformにある 現在位置xとyを、いったんVector2 型の変数にいれる
        position.x = position.x + 0.1f; //「変更」：positionのxへ0.1を加える (x座標が0.1右へ)
        transform.position = position; //「反映」：Transform へ変更した値(新しい位置)を設定しなおす
        */
        //-> 新しいフレーム(デフォルトは60/1s)毎に、現在位置が0.1右へ書き出される -> 連続的に右へ移動してるように見える


        /*
        float:小数点付きの数値を格納する変数
        Input.GetAxis("Horizontal"): ProjectSetting -> InputManager -> 水平方向Horaizotal を取得する関数(GetAxis関数)
        */
        /*
        float horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal); //console へキーボードで入力された値を書き込む(←：-1、→：1？)
        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal; //キーボード上で←押すと「マイナス」、→なら「プラス」…0.1移動。押さなければ0で不動。
        transform.position = position;
        // -> 水平(横)方向の設定

        float vertical = Input.GetAxis("Vertical");
        Debug.Log(vertical); //console へキーボードで入力された値を書き込む(←：-1、→：1？)
        position.y = position.y + 0.1f * vertical; //キーボード上で←押すと「マイナス」、→なら「プラス」…0.1移動。押さなければ0で不動。
        transform.position = position;
        // -> 垂直(縦)方向の設定
        */

        /*
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;
        transform.position = position;
        */
        // -> 移動量をフレームあたりでなく、1秒あたりの単位で表すために
        // Time.deltaTime をかける　()　->
        // (毎秒10フレームの場合、各フレームには0.1秒。60フレームは、各0.017秒かかる)
        // レンダリングされたフレーム数に関係なく、キャラクターは同じ速度で実行される。現在は「フレーム非依存」

        if (flowchart1.GetBooleanVariable("IsTalking") || flowchart2.GetBooleanVariable("IsTalking"))
        {
            //Debug.Log("Don't move!");

            move = new Vector2(0, 0);
            animator.SetFloat("Speed", move.magnitude);
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            move = new Vector2(horizontal, vertical);

            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);
        }
    }

    private void FixedUpdate()
    {
        if (flowchart1.GetBooleanVariable("IsTalking") || flowchart2.GetBooleanVariable("IsTalking"))
        {
        }
        else
        {
            // 移動量を加算する
            Vector2 position = rigidbody2d.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        }
    }
}
