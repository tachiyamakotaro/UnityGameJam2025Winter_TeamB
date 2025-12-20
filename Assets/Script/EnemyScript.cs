using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]GameObject Player;
    PlayerScript playerScript;
    Vector2 PlayerPos;

    [SerializeField] float speed = 3.0f;

    Vector3 diff;
    Vector3 vector;

    private Rigidbody2D rb;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if(Player!= null)
        {
            playerScript = Player.GetComponent<PlayerScript>();
        }
       
            //playerScript = Player.GetComponent<PlayerScript>();
        //PlayerPos = Player.transform.position;
        //this.transform.LookAt(PlayerPos);
        rb = GetComponent<Rigidbody2D>();
    }

   
    void FixedUpdate()
    {
        //プレイヤーの現在の位置を取得
        PlayerPos = playerScript.GetPosition();
        //現在位置からプレイヤ－の位置に向けて移動
        //transform.position = Vector2.MoveTowards(transform.position, PlayerPos, speed * Time.deltaTime);
        Vector2 nextPos= Vector2.MoveTowards(rb.position, PlayerPos, speed * Time.fixedDeltaTime);
        rb.MovePosition(nextPos);
        //プレイヤーとエネミーのX軸の位置関係を取得する
        diff.x = PlayerPos.x - rb.position.x;
        //プレイヤーがエネミーの右側にいるとき右を向く
        if(diff.x >0)
        {
            //vector = new Vector3(0, -180, 0);
            //transform.eulerAngles = vector;
            transform.localScale = new Vector3(1, 1, 1);
        }
        //Playerが敵キャラの左側にいるとき左側を向く
        if(diff.x < 0)
        {
            //vector = new Vector3(0, 0, 0);
            //transform.eulerAngles = vector;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
