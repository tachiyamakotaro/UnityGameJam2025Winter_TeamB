using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDataScript : MonoBehaviour
{

    public static ResultDataScript Instance;

    // 上昇したボーナス情報すべて保存
    public List<BonusStats> totalGainedBonuses = new List<BonusStats>();

    public int finalPlayerLevel = 1;

    private void Awake()
    {
        // シングルトン処理（複製を防止）
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーン切替で消さない
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // リセット（タイトルで使う）
    public void ResetData()
    {
        totalGainedBonuses.Clear();
        finalPlayerLevel = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
