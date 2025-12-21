using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class WeponScript : MonoBehaviour
{
    [Header("CoolDown Settings")]
    //武器ごとのクールタイム。
    public float coolTime = 0.86f;

    [SerializeField]
    protected PlayerStateScript playerState;
    enum MoveState
    {
        Forward,
        Return
    }
    MoveState moveState;

    public float speed = 7.0f;
    public float maxDistance = 10.0f;
    public float returnSpeed = 6.4f;
    public float catchDistance = 0.4f;

    [SerializeField]
    protected Transform player;
    protected Vector2 startPos;
    protected Vector2 forwardDir;


    // Start is called before the first frame update
    protected void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        WeponAction();
    }

    public virtual void WeponAction()
    {
        if (player == null) return;
        Vector2 currentPos = transform.position;

        if (moveState == MoveState.Forward)
        {
            currentPos += forwardDir * speed * Time.deltaTime;

            if (Vector2.Distance(startPos, transform.position) >= maxDistance)
            {
                moveState = MoveState.Return;
            }
        }
        else
        {
            Vector2 dir = ((Vector2)player.position - currentPos).normalized;
            currentPos += dir * returnSpeed * Time.deltaTime;

            if (Vector2.Distance(transform.position, player.position) <= catchDistance)
            {
                Destroy(gameObject);
                return;
            }
        }
        transform.position = currentPos;
    }

    public void Initialize()
    {
        startPos = transform.position;
        forwardDir = player.transform.right;
        moveState = MoveState.Forward;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //TODO:Enemyにダメージを与えるところエネミー担当の人はここを
            //var enemyとかにしてGetComponentしてエネミーがnullじゃないときに
            //ダメージを与えるようにしてください。
        }
    }
}
