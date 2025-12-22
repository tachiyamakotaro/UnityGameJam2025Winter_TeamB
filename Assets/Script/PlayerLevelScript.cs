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

    private LevelUpUIScript ui;

    [SerializeField] private ItemSelectUIScript ItemSelectUIScript;

    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<LevelUpUIScript>();

        onLevelUp += () =>
        {
            Debug.Log("aaaaaaa");
            ui.ShowLevelUp(level);
            ItemSelectUIScript.OpenUI();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //経験値を加算する関数
    public void AddExp(int exp)
    {
        currentExp += exp;
        Debug.Log($"EXPGET:{exp}/{currentExp}/{nextExp}");

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

        Debug.Log($"LEVELUP　LEVEL:{level}");

        onLevelUp?.Invoke();
    }
}
