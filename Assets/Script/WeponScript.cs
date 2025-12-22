using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class WeponScript : MonoBehaviour
{
    [Header("CoolDown Settings")]
    //武器ごとのクールタイム。
    public float coolTime = 0.86f;
    private static Dictionary<System.Type, float> nextAttackTimes = new Dictionary<System.Type, float>();
    
    //その武器種(クラス)が現在クールタイム中か判定するメソッド
    public bool IsWeaponTypeCoolingDown()
    {
        float nextTime;
        if (nextAttackTimes.TryGetValue(this.GetType(), out nextTime))
        {
            return Time.time < nextTime;
        }
        return false;
    }

    //更新クールタイム処理。
    public void UpdateCoolTime()
    {
        nextAttackTimes[this.GetType()] = Time.time + coolTime;
    }

    public void SetPlayer(Transform plaTra,PlayerStateScript stateSc)
    {
        player = plaTra;
        playerState = stateSc;
    }

    public void Initialize()
    {
        startPos = transform.position;
        forwardDir = player.transform.right;
        moveState = MoveState.Forward;

        //生成された瞬間に、その「クラス型」の次回攻撃時間を更新する
        //nextAttackTimes[this.GetType()] = Time.time + coolTime;
    }

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

    [Header("攻撃力")]
    public float damage = 10f; // 武器の基本攻撃力


    //クールタイム中かどうか確認するプロパティ
    //public static bool IsCoollingDown => Time.time - lastAttackTime < 0.86;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Initialize();

        if (playerState != null)
        {
            playerState.currentWeapon = this;
        }
           
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

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //TODO:Enemyにダメージを与えるところエネミー担当の人はここを
            //var enemyとかにしてGetComponentしてエネミーがnullじゃないときに
            //ダメージを与えるようにしてください。
            var enemy = other.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.TakeDamage((int)damage);//インスペクターのダメージを反映
            }
            // を実装して下さい。
            //TakeDamageはダメージを受ける処理に変えてください。
        }
    }
}
