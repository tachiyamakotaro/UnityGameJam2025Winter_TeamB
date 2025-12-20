using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelScript : WeponScript
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        coolTime = 0.5f;
    }


    public override void WeponAction()
    {
        base.WeponAction();
        //Playerに戻らずに消滅。
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
            }
        }
    }
}
