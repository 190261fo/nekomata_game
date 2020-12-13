using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NekomataController : MonoBehaviour
{
    //キャラの移動速度変更用
    public float speed = 3.0f;

    //「ヘルス」の追加
    public int maxHealth = 5; //Unityでも変更できるし、そちらが優先される

    public float timeInvincible = 2.0f; //Unityで微調整できるようにpublicに(ダメージゾーン用)

    public int health { get { return currentHealth; }} //プロパティ定義
    int currentHealth; // publicにしたくない、ほかのスクリプトで参照はしたい↑

    public GameObject projectilePrefab;

    //ダメージゾーン用
    bool isInvincible;
    float invincibleTimer;

    //宣言
    public Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;

    public Animator animator;
    public Vector2 lookDirection = new Vector2(1,0);
    public Vector2 move;

    //開始関数(update関数の前に1度だけ呼び出される)
    void Start()
    {
        // ↓どのスペックでも同じになるようにゲームの速度を制御(現在は必要ない)
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10; // 10フレーム/1sに設定し直す

        rigidbody2d = GetComponent<Rigidbody2D>();
        // rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator = GetComponent<Animator>();

        //スタート時はヘルスはMax
        currentHealth = maxHealth;

        // currentHealth = 1; //回復アイテムの取得・効果がわかるように設定し直した
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
        position.x = position.x + 0.1f * horizontal;
        position.y = position.y + 0.1f * vertical;
        transform.position = position;
        */

        /*
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;
        transform.position = position;
        */
        // -> Rubyの移動量をフレームあたりでなく、1秒あたりの単位で表すために
        // Time.deltaTime をかける　()　->
        // (毎秒10フレームの場合、各フレームには0.1秒。60フレームは、各0.017秒かかる)
        // レンダリングされたフレーム数に関係なく、キャラクターは同じ速度で実行される。現在は「フレーム非依存」

        /*
        horizontal = Input.GetAxis("Horizontal"); //入力を読み取るだけ に変更
        vertical = Input.GetAxis("Vertical");
        */
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        move = new Vector2(horizontal, vertical);
        

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
                
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {
            //無敵時間を計りたい
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                //無敵時間(現在は2秒)が終わったら、無敵状態じゃなくなる
                isInvincible = false;
            }
        }

        // if(Input.GetKeyDown(KeyCode.C))
        // {
        // Launch();
        // }
    }

    private void FixedUpdate()
    {
        // 移動量を加算する
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
        
    }

    public void ChangeHealth(int amount)
    {
        /*
        //Cramp <- 現在のヘルスと追加を合わせても、0以上Max値（5）以下になるよう設定
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        */

        if (amount < 0)
        {
            if (isInvincible)
                //無敵状態なら、そのままリターン
                return;
            
            //そうでなければ、無敵状態に戻し、無敵時間を初期化(2秒)
            isInvincible = true;
            invincibleTimer = timeInvincible;

            animator.SetTrigger("Hit");
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }

    public void Stop()
    {
        move = Vector2.zero;
        animator.SetFloat("Look X", 0);
        animator.SetFloat("Look Y", 0);
    }
}
