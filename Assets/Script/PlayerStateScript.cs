using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateScript : MonoBehaviour
{
    //最大のHP。
    public float maxHp = 100.0f;
    //現在のHP。
    public float currentHp;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ダメージ処理。
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        //現在のHPが0になると
        if(currentHp < 0.0f)
        {
            currentHp = 0.0f;
            //死亡ログが流れる。
            Die();
        }
    }

    //デバックログ。
    void Die()
    {
        Debug.Log("Dead");
    }
}
