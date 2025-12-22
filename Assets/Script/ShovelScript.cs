using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelScript : WeponScript
{
    private void Awake()
    {
        //親クラスが動き出す前にクールタイムト攻撃力をセット
        coolTime = 0.5f;
        damage = 15.0f;
    }




    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
       
    }


    public override void WeponAction()
    {

        if(player ==null)
        {
            return;
        }

        //前方に進み続ける
        transform.position += (Vector3)forwardDir * speed * Time.deltaTime;

        //一定距離進んだら消滅
        if (Vector2.Distance(startPos, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                //TODO::ダメージ。5ダメージがいいな。
                enemy.TakeDamage(15);
            }
        }
    }
}
