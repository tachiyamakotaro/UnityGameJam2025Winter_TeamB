using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;


public class ResultUIScript : MonoBehaviour
{

    public TMP_Text hpText;
    public TMP_Text atkText;
    public TMP_Text levelText;

    // Start is called before the first frame update
    void Start()
    {

        float totalHP = ResultDataScript.Instance.totalGainedBonuses
            .Where(b => b.statType == StatType.HP && b.bonusType == BonusType.Add)
            .Sum(b => b.value);

        float totalATK = ResultDataScript.Instance.totalGainedBonuses
            .Where(b => b.statType == StatType.ATK && b.bonusType == BonusType.Add)
            .Sum(b => b.value);

        int lv = ResultDataScript.Instance.finalPlayerLevel;

        hpText.text = $"HPUP TOTAL : {totalHP}";
        atkText.text = $"ATKUP TOTAL : {totalATK}";
        levelText.text = $"LEVEL : Lv.{lv}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
