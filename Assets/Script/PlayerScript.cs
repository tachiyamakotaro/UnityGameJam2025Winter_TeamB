using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //プレイヤーの移動。
    private void PlayerMove()
    {
        //移動キー。
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //移動量の計算。
        Vector3 move = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;

        //位置の更新。
        transform.position += move;
    }

    //GetPositonの追加。
    public Vector3 GetPositon()
    {
        return transform.position;
    }
}
