
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour

{

    private float speed = 5.0f;

    private Rigidbody2D rb;

    private Vector2 movement;

    [SerializeField] HpBarScript hpBar;

    [SerializeField]
    private GameObject[] prefs;

    [SerializeField]
    PlayerStateScript playerStateScript;

    // Start is called before the first frame update

    void Start()

    {
        StartCoroutine("Coroutine");
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame

    void Update()

    {

        //Move();

        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

    }

    IEnumerator Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            var index = Random.Range(0, prefs.Length);
            Attack(prefs[index]);
        }

    }

    void FixedUpdate()

    {

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }

    private void Move()

    {

        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;

        transform.position += move;

    }

    public Vector3 GetPosition()

    {

        return rb.position;

    }

    public void Attack(GameObject prefab)
    {
        WeponScript ws = prefab.GetComponent<WeponScript>();
        ws.SetPlayer(transform, playerStateScript);

        // 1. その武器種（型）がクールタイム中かチェック
        if (ws != null && !ws.IsWeaponTypeCoolingDown())
        {
            // 2. 発射（生成）
            Instantiate(prefab, transform.position, transform.rotation);

            // 3. 発射したプレハブの coolTime（0.5秒や1.24秒など）を使って次を予約
            ws.UpdateCoolTime();
        }
    }
}

