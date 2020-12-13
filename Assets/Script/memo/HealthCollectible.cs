using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //    Debug.Log("Object that entered the trigger : " + other);

        NekomataController controller = other.GetComponent<NekomataController>();

        if (controller != null)
        {
            // controller.ChangeHealth(1);
            // Destroy(gameObject);
            // -> ヘルスがMAXだとしても取得(イチゴ消)しちゃう

            //MAXならスルー、未満なら↓の処理
            /*
            （currentHealthはpublicにしたくないので呼べない）
            if(controller.currentHealth < controller.maxHealth)
            */
            // health を呼ぶことでcurrentHealthの値を取得できる
            if(controller.health < controller.maxHealth)
            {
	            controller.ChangeHealth(1);
	            Destroy(gameObject);

                /*
                ここで、
                controller.health = 10;
                などはできない。healtyは現在getのみ(読み取り専用)の設定だから
                */
            }
        }
    }
}
