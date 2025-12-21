using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelScript : MonoBehaviour
{
    [Header("レベルパラメータ")]
    public int level = 1;               //現在のレベル
    public int currentExp = 0;          //現在の経験値
    public int nextExp = 10;       //次のレベルに必要な経験値

    //レベルアップの通知を送る
    public Action onLevelUp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //経験値を加算する関数
    public void AddExp(int exp)
    {
        currentExp += exp;
        Debug.Log($"EXP獲得:{exp}/現在{currentExp}/{nextExp}");

        if(currentExp>=nextExp)
        {
            LevelUp();
        }
    }

    //レベルアップ処理
    private void LevelUp()
    {
        level++;
        currentExp -= nextExp; //超えた経験値を計算
        nextExp += 10; //レベルアップに必要な経験値を増やす

        Debug.Log($"レベルアップ　現在のレベル:{level}");

        onLevelUp.Invoke();
    }
}
