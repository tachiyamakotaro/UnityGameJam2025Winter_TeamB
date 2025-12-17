using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    //前フレームでのプレイヤーの座標位置。
    Vector3 prePlayerPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    //追従。
    public void Follow()
    {
        if (Player.transform.position != prePlayerPos)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
            prePlayerPos = Player.transform.position;
        }
    }
}
