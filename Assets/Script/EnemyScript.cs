using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject Player;
    Vector3 PlayerPos;

    [SerializeField] float speed = 3.0f;

    Vector3 diff;
    Vector3 vector;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerPos = Player.transform.position;
        this.transform.LookAt(PlayerPos);
    }

   
    void Update()
    {
        //プレイヤーの現在の位置を取得
        PlayerPos = Player.transform.position;
        //現在位置からプレイヤ－の位置に向けて移動
        transform.position = Vector2.MoveTowards(transform.position, PlayerPos, speed * Time.deltaTime);
        //プレイヤーとエネミーのX軸の位置関係を取得する
        diff.x = PlayerPos.x - this.transform.position.x;
        //プレイヤーがエネミーの右側にいるとき右を向く
        if(diff.x >0)
        {
            vector = new Vector3(0, -180, 0);
            this.transform.eulerAngles = vector;
        }
        //Playerが敵キャラの左側にいるとき左側を向く
        if(diff.x < 0)
        {
            vector = new Vector3(0, 0, 0);
            this.transform.eulerAngles = vector;
        }
    }
}
