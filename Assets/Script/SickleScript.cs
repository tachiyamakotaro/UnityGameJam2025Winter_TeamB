using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleScript : WeponScript
{
    //回転速度。
    public float rotateSpeed = 360.0f;


    private void Awake()
    {
        coolTime = 2.4f;
        damage = 15.0f;
    }

    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
      
    }

    public override void WeponAction()
    {
        //ベースの「移動処理」を実行。
        base.WeponAction();

        //自分自身を回転。
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if(other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                //TODO:ダメージ。15ダメージがいいな。
                enemy.TakeDamage(20);
            }
        }
    }
}
