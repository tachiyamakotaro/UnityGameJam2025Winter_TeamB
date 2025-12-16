using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestScript : MonoBehaviour
{
    [SerializeField]Vector2 position;

    [SerializeField]float deleteTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //一定時間経過で宝箱を削除
        deleteTime -= Time.deltaTime;
        if (deleteTime <= 0)
        {
            Destroy(gameObject);
        }
           
    }

    //プレイヤーが宝箱に触れたとき
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        ////宝箱を開けるアニメーションを再生
    //        //GetComponent<Animator>().SetTrigger("Open");
    //        ////アイテムを生成
    //        //Instantiate(Resources.Load("Prefabs/Item/HealthPotion"), transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    //        //宝箱を削除
    //        Destroy(gameObject, 0.5f);
    //    }
    //}
}
