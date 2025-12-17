
using System.Collections;
=======
﻿using System.Collections;

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


    //�v���C���[�̈ړ��B
    private void PlayerMove()
    {
        //�ړ��L�[�B
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //�ړ��ʂ̌v�Z�B
        Vector3 move = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;

        //�ʒu�̍X�V�B
        transform.position += move;
    }

    //GetPositonの追加。
    public Vector3 GetPositon()
    {
        return transform.position;
    }
}
