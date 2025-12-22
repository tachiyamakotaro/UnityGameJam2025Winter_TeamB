using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float Speed = 3.0f;
    [SerializeField] private GameObject coinPrefab;//ドロップするコインのプレハブ
    [SerializeField] private int maxHP = 100;//最大HP
    private int currentHp;//現在のHP

    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        //初期HPを設定
        currentHp = maxHP;
    }

   
    void FixedUpdate()
    {
        if(player ==null)
        {
            return;
        }

        Vector2 playerPos = player.transform.position;
        Vector2 currentPos = transform.position;

        //移動の処理
        //MoveTowardsで算出した位置へRigitbodyを移動
        Vector2 nextPos = Vector2.MoveTowards(currentPos, playerPos, Speed * Time.fixedDeltaTime);
        rb.MovePosition(nextPos);

        //向きの処理
        float diffX = playerPos.x - currentPos.x;

        if(diffX > 0)
        {
            //右側にプレイヤーがいるとき
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        else if(diffX < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    


    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if(currentHp <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        //コインをエネミーの現在位置に生成
        if(coinPrefab != null)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }

        //エネミーを削除
        Destroy(gameObject);
    }
}
