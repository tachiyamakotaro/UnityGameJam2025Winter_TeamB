using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemScript : ScriptableObject
{
    public List<ItemData> datas;

    static ItemScript instance;
    public static ItemScript Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<ItemScript>(nameof(ItemScript));
            }
            return instance;
        }
    }
    
    public ItemData Get(int id)
    {
        return (ItemData)datas.Find(item => item.id == id);
    }
}

public enum BonusType
{
    Percent,
    Add
}

public enum StatType
{
    HP,
    ATK
}

[System.Serializable]
public class BonusStats
{
    public StatType statType;
    public BonusType bonusType;
    public float value;
}

[System.Serializable]
public class ItemData
{
    public string Title;

    //アイテムの名前
    public string itemName;
    //アイテムのID
    public int id;
    //アイテムの説明
    [TextArea] public string description;
    //アイテムのアイコン
    public Sprite icon;
    //bo-nasu
    //public List<BonusStats> Bonuses;

    public List<BonusStats> Bonuses=new List<BonusStats>();

    public ItemData GetCopy()
    {
        return (ItemData)MemberwiseClone();
    }
}
