using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float Speed = 3.0f;
    private Rigidbody2D rb;

    //今までのコード
    //GameObject Player;
    //Vector3 PlayerPos;

    //private float speed =3.0f;

    //Vector3 diff;
    //Vector3 vector;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        //今までのコード
        //Player = GameObject.FindGameObjectWithTag("Player");
        //PlayerPos = Player.transform.position;
        //this.transform.LookAt(PlayerPos);
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




        //今までのコード
        //    PlayerPos = Player.transform.position;//プレイヤーの現在位置を取得
        //    transform.position = Vector2.MoveTowards(transform.position, PlayerPos, speed * Time.deltaTime);//現在位置からプレイヤーの位置に向けて移動



        //    diff.x = PlayerPos.x - this.transform.position.x;//プレイヤーと敵キャラのX軸の位置関係を取得する
        //    if (diff.x > 0)
        //    {//Playerが敵キャラの右側にいる時右側を向く
        //        vector = new Vector3(0, -180, 0);
        //        this.transform.eulerAngles = vector;
        //    }
        //    if (diff.x < 0)
        //    {//Playerが敵キャラの左側にいる時左側を向く
        //        vector = new Vector3(0, 0, 0);
        //        this.transform.eulerAngles = vector;





        //    //if(PlayerPos.x > transform.position.x)
        //    //{
        //    //    //右向き
        //    //    transform.eulerAngles = new Vector3(0, 180, 0);
        //    //}

        //    //else
        //    //{
        //    //    transform.eulerAngles = new Vector3(0, 0, 0);
        //    //}
    }
}
