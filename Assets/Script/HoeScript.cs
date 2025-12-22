using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoeScript : WeponScript
{
    public float StraightSpeed = 8.2f;
    // Start is called before the first frame update
    private void Start()
    {
        base.Start();
        coolTime = 1.24f;

        damage = 10.0f;
    }

    public override void WeponAction()
    {
        base.WeponAction();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyScript>();
            if(enemy != null)
            {
                //TODO:ダメージ。10ダメージがいいな。
            }
        }
    }
}
