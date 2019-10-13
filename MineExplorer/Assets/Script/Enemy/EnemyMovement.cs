//-------------------------------------------------------//
// エネミーの移動処理 プレイヤーの追跡(NavMesh使用)
//                                    2019 Yutaro Ono.
//-----------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // NavMeshAgentの取得
    public NavMeshAgent enemyNav;

    // エネミーの移動速度
    public Vector3 moveSpeed = new Vector3(0f,0f,0f);

    // エネミーの巡回用タイマー(指定秒ごとに目的地を変える)
    private float m_patrolTimer;

    // 巡回時の目標地点座標
    private Vector3 m_targetPos;

    // ターゲティングするプレイヤーオブジェクト格納用
    private GameObject tagPlayer;

    // エネミーの索敵オブジェクト
    [SerializeField] GameObject m_searchObj;
    // エネミーの索敵処理コンポーネント
    private SearchPlayer m_searchComp;

    // Start is called before the first frame update
    void Start()
    {
        m_patrolTimer = 0.0f;
        m_targetPos = new Vector3(0.0f, 0.0f, 0.0f);


        // 自身のNavMeshAgentの取得
        enemyNav = gameObject.GetComponent<NavMeshAgent>();

        // プレイヤーオブジェクトを取得
        tagPlayer = GameObject.Find("Player");

        // 索敵コンポーネントの取得
        m_searchComp = m_searchObj.GetComponent<SearchPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        // エネミーがプレイヤーを見つけていた場合、プレイヤーを追尾
        if(m_searchComp.isDetected == true)
        {
            // ターゲット(プレイヤー位置)に自動移動する
            enemyNav.destination = tagPlayer.transform.position;

            // NavMeshAgentの加速度を移動速度として保管
            moveSpeed = enemyNav.velocity;
        }
        // 見つけていなかった場合
        else
        {
            // NavMesh停止
            enemyNav.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            // 移動速度を0に
            moveSpeed = new Vector3(0.0f, 0.0f, 0.0f);
        }


    }

    // エネミーの巡回関数(廃止)
    private void Patrol()
    {
        float timer = 5.0f;

        // 巡回時間が0以下のとき設定
        if(m_patrolTimer <= 0.0f)
        {
            m_patrolTimer = timer;
        }

        // パトロールタイマーが更新されたら目的地を新規設定
        if(m_patrolTimer == timer)
        {
            m_targetPos = new Vector3(Random.Range(-1000.0f, 3000.0f), 0.0f, Random.Range(-1000.0f, 3000.0f));

        }

        enemyNav.destination = m_targetPos;

        // 巡回時間を減らす
        m_patrolTimer -= Time.deltaTime;
        
    }

}
