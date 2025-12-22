using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateScript : MonoBehaviour
{
    //最大のHP。
    public float maxHp = 100.0f;
    //現在のHP。
    public float currentHp;

    [Header("武器")]
    public WeponScript currentWeapon; //現在装備中の武器
    
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ダメージ処理。
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        //現在のHPが0になると
        if(currentHp < 0.0f)
        {
            currentHp = 0.0f;
            //死亡ログが流れる。
            Die();
        }
    }

    //デバックログ。
    void Die()
    {
        Debug.Log("Dead");
    }

    //アイテムのステータス反映
    public void ApplyItem(ItemData item)
    {
        foreach(var bonus in item.Bonuses)
        {
            switch(bonus.statType)
            {
                case StatType.HP:
                    //HP増加処理
                    if(bonus.bonusType==BonusType.Add)
                    {
                        maxHp += bonus.value;
                    }
                    else if(bonus.bonusType==BonusType.Percent)
                    {
                        maxHp += maxHp * bonus.value / 100f;
                    }

                    //現在HPも補正
                    currentHp = Mathf.Min(currentHp + bonus.value, maxHp);
                    break;

                case StatType.ATK:
                    //武器の攻撃力増加
                    if (currentWeapon != null)
                    {
                        if (bonus.bonusType == BonusType.Add)
                        {
                            currentWeapon.damage += bonus.value;
                        }
                        else if (bonus.bonusType == BonusType.Percent)
                        {
                            currentWeapon.damage += currentWeapon.damage * bonus.value / 100f;
                        }
                    }
                    break;
            }
        }
        Debug.Log($"Item Applied: {item.Title} / new HP={maxHp}");
    }

    public void EquipWeapon(WeponScript weapon)
    {
        //currentWeapon = weapon;
        //weapon.playerState = this;
        //weapon.player = this.transform;
    }
}
