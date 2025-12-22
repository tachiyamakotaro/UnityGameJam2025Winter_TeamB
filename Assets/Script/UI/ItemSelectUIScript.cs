using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSelectUIScript : MonoBehaviour
{

    //ヒエラルキーでボタンを三つ作成
    public Button[] choiceButtons = new Button[3];

    //アイテム選択UIを表示
    private List<ItemData> candidates = new List<ItemData>();

    //インベントリへの参照
    [SerializeField] PlayerItemInventoryScript inventory;

    [SerializeField] PlayerStateScript player;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<PlayerItemInventoryScript>();

        gameObject.SetActive(false);

        SetupButtonEvents();
    }

    //i番目の候補を選択、インベントリに追加
    void SetupButtonEvents()
    {
       for(int i=0;i<choiceButtons.Length; i++)
        {
            int index = i;
            choiceButtons[i].onClick.AddListener(() =>
            {
                SelectItem(index);
            });
        }
    }

    //UIを表示
    //プレイヤーがレベルアップしたときなどにOpenUI()を呼び出す
    public void OpenUI()
    {
        //ランダムに3つの候補を取得
        candidates = GetRandomCandidates(3);

        //ボタンに候補を表示
        UpdateUIButtons();

        //UIを表示
        gameObject.SetActive(true);

        Time.timeScale = 0f;
    }

    //ボタンテキストを更新処理
    void UpdateUIButtons()
    {
        for(int i=0;i<choiceButtons.Length;i++)
        {
            TMP_Text txt = choiceButtons[i].GetComponentInChildren<TMP_Text>();

            txt.text=candidates[i].Title;
        }
    }

    //プレイヤーがボタンを押したとき
    void SelectItem(int index)
    {
        ItemData selected=candidates[index];

        Debug.Log($"SELECT ITEM:{selected.Title}");

        //インベントリに追加
        inventory.AddItem(selected);

        if(player!=null)
        {
            player.ApplyItem(selected);
        }

        // BonusStats をそのまま保存
        foreach (var bonus in selected.Bonuses)
        {
            ResultDataScript.Instance.totalGainedBonuses.Add(bonus);
        }

        //UIを閉じる
        CloseUI();
    }

    //UIを閉じる
    public void CloseUI()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
       
    }

    //ランダムに候補を取得
    List<ItemData>GetRandomCandidates(int count)
    {
        Debug.Log(ItemScript.Instance);
        Debug.Log(ItemScript.Instance.datas.Count);
        List<ItemData> result = new List<ItemData>();
        List<ItemData> pool = ItemScript.Instance.datas;

        for(int i=0;i<count;i++)
        {
            ItemData pick = pool[UnityEngine.Random.Range(0, pool.Count)];
            result.Add(pick);
        }

        return result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
