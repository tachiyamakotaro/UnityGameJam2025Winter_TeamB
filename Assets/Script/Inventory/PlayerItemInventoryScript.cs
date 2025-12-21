using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemInventoryScript : MonoBehaviour
{
    // Start is called before the first frame update

    //何を所持しているかのリスト
    private List<ItemData> ownedItems = new List<ItemData>();

    //同じIDのアイテムをまとめる用
    private Dictionary<int, int> itemStacks = new Dictionary<int, int>();

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
        if (item == null)
        {
            //アイテムがnullの場合は警告を出して終了
            Debug.LogWarning("AddItem: item is null");
            return;
        }

        ownedItems.Add(item);
        Debug.Log($"{item.Title}を取得しました。");

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

    //累積数確認
    public int CountByID(int id)
    {
        return ownedItems.FindAll(i => i.id == id).Count;
    }

    public List<ItemData> GetItemsByID(int id)
    {
        return ownedItems.FindAll(i => i.id == id);
    }

    public void AddItemStack(ItemData item)
    {
        if(item==null)
        {
            return;
        }

        if(!itemStacks.ContainsKey(item.id))
        {
            itemStacks[item.id] = 0;
        }

        itemStacks[item.id]++;

        Debug.Log($"{item.Title}*{itemStacks[item.id]}");
    }

    public int GetStack(int id)
    {
        if(!itemStacks.ContainsKey(id))
        {
            return 0;
        }
        return itemStacks[id];
    }
}
