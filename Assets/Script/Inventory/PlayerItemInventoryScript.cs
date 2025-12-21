using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemInventoryScript : MonoBehaviour
{
    // Start is called before the first frame update

    private List<ItemData> ownedItems = new List<ItemData>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //アイテムを追加する
    public void AddItem(ItemData item)
    {
        if(item==null)
        {
            //アイテムがnullの場合は警告を出して終了
            Debug.LogWarning("AddItem: item is null");
            return;
        }

        ownedItems.Add(item);
        Debug.Log($"AddItem: {item.Title}を取得しました。");

        ///アイテムを取得したいタイミングで
        ///　var item=ItemScript.Instance.Get(0); 
        ///　ID0のアイテムを取得　//IDはResource/NewItem内で確認できる
        ///　var inv =FindObjectOfType<PlayerItemInventory>();
        ///　inv.AddItem(item);
        ///　を書くことでアイテムを所持品に追加できる
    }

    //所持数を返す
    public int GetItemCount()
    {
        return ownedItems.Count;
    }

    //アイテムリストを返す(UI用)
    public List<ItemData> GetAllItems()
    {
        return ownedItems;
    }

}
