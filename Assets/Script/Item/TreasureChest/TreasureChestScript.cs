using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestScript : MonoBehaviour
{
    [SerializeField]Vector3 position;

    [SerializeField]float deleteTime = 3.0f;

    [SerializeField]GameObject player;
    [SerializeField] Collider2D plColl;

    float openDistance = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
       // position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter2D(plColl);
    }

    //プレイヤーが宝箱に触れたとき
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            //プレイヤーと宝箱の距離を計算
            float distance = Vector3.Distance(player.transform.position, position);
            //距離が一定以下なら宝箱を開ける
            if(distance <= openDistance)
            {
              Destroy(gameObject, deleteTime);
            }
        }
    }
}
