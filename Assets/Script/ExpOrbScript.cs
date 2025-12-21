using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrbScript : MonoBehaviour
{
    public int expAmount = 1;       // このオーブが付与するEXP量
    public float suckSpeed = 5f;    // 吸い込むスピード

    private Transform player;       // プレイヤー参照
    private PlayerLevelScript level;

    // Start is called before the first frame update
    void Start()
    {
        // Playerを探す
        player = GameObject.FindGameObjectWithTag("Player").transform;
        level = player.GetComponent<PlayerLevelScript>();
    }

    // Update is called once per frame
    void Update()
    {
       if(player==null)
        {
            return;
        }

        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * suckSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            level.AddExp(expAmount);
            Destroy(gameObject);
        }
    }
}
