
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{

    [SerializeField]
    //生成する用の敵キャラクターのprefabを読み込む
    private GameObject [] EnemyPrefabs;
    //キャラクターの位置を代入する変数
   [SerializeField] private float span = 1f;
    private float currentTime = 0f;

    GameObject Player;
    Vector2 PlayerPos;
    Vector2 enemyspawnPos;
  
    //生成される方向を決める乱数用の変数
    int rndUD;//上下
    int rndLR;//左右
    void Start()
    {
        //Playerというタグを検索して、、見つかったオブジェクトに代入する
        Player = GameObject.FindGameObjectWithTag("Player");
    }

  
    void Update()
    {
        //時間経過をcurrentTimeに代入して時間を測る
        currentTime += Time.deltaTime;
       if( currentTime > span ) 
        {
            //リストからランダムに1種類選ぶ
            int randomIndex = Random.Range(0, EnemyPrefabs.Length);
            EnemyGenerate(EnemyPrefabs[randomIndex]);
            currentTime = 0.0f;
        }
        
    }


    public void EnemyGenerate(GameObject Enemy)
    {
        //EnemyPrefabのスポーン位置を決める
        //Playerの現在位置を取得
        PlayerPos = Player.transform.position;

        //上下どちらにスポーンするか
        rndUD = Random.Range(0, 2);//0:上 1:右下        //左右どちらか
        rndLR = Random.Range(0, 2);//0:左 1:右

        //プレイヤーからどれくらい離れた位置で生成するか
        float rndX = Random.Range(0, 2) == 0 ? Random.Range(8f, 10f) : Random.Range(-10f, -8f);
        float rndY = Random.Range(0, 2) == 0 ? Random.Range(8f, 10f) : Random.Range(-10f, -8f);

        //プレイヤーの位置に先ほどの乱数を足した位置に生成する
        enemyspawnPos = new Vector2(rndX, rndY) + PlayerPos;
        //親子関係を作らずに生成
        Instantiate(Enemy, enemyspawnPos, Quaternion.identity);
    }

}
