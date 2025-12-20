using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField]
    //生成する用の敵キャラクターのprefabを読み込む
    private GameObject EnemyPrefab;
    GameObject Player;
    //キャラクターの位置を代入する変数
    Vector2 PlayerPos;
    private float currentTime = 0f;
    private float span = 5f;
    //生成される方向を決める乱数用の変数
    int rndUD;//上下
    int rndLR;//左右
    Vector2 enemyspawnPos;
    void Start()
    {
        //Playerというタグを検索して、、見つかったオブジェクトに代入する
        Player = GameObject.FindGameObjectWithTag("Player");
    }

  
    void Update()
    {
        //時間経過をcurrentTimeに代入して時間を測る
        currentTime += Time.deltaTime;
        if(currentTime > span)
        {
            EnemyGenerate(EnemyPrefab);
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
        float rndPositiveX = Random.Range(8.0f, 10.0f);
        float rndPositiveY = Random.Range(8.0f, 10.0f);
        float rndNegativeX = Random.Range(-10.0f, -8.0f);
        float rndNegativeY = Random.Range(-10.0f, -8.0f);

        switch(rndUD)
        {
            //randUDが上の時
            case 0:
                enemyspawnPos.y = rndPositiveY;//上方向の乱数を代入
                break;

            //rndUDが下の時
            case 1:
                enemyspawnPos.y = rndNegativeX;//下方向の乱数を代入
                break;
        }


        switch(rndLR)
        {
            case 0:
                enemyspawnPos.x = rndPositiveX;//左方向の乱数を代入
                break;

            case 1:
                enemyspawnPos.x = rndNegativeX;//右方向の乱数を代入
                break;
        }
        //プレイヤーの位置に先ほどの乱数を足した位置に生成する
        enemyspawnPos = enemyspawnPos + PlayerPos;
        var enemy = Instantiate(Enemy, enemyspawnPos, Quaternion.identity);//Prefabを生成する。
    }


}
