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

    // エネミーコントローラー
    private EnemyController m_enemyCtrl;

    // パトロールマネージャー(プレイヤー、巡回地点の座標情報が入っている)
    private EnemyPatrolManager patrolManager;
    // マネージャーを保管している巡回地点オブジェクト
    [SerializeField] GameObject m_patrolObj;

    // NavMeshAgentの取得
    public NavMeshAgent enemyNav;

    // エネミーの移動速度
    public Vector3 moveSpeed = new Vector3(0f, 0f, 0f);

    // 次の巡回地点に移動するまでの時間
    public float changeNextPointTimer = 5.0f;
    // エネミーの巡回用タイマー(指定秒ごとに目的地を変える)
    [SerializeField] float m_patrolTimer;

    // 次回目的地設定用ID
    [SerializeField] int m_nextPatrolPos = 0;


    // エネミーの索敵範囲オブジェクト
    [SerializeField] GameObject m_searchArea;
    // エネミーの索敵処理コンポーネント
    private SearchPlayer m_searchComp;

    // Start is called before the first frame update
    void Start()
    {
        m_patrolTimer = 0.0f;

        // EnemyController取得
        m_enemyCtrl = gameObject.GetComponent<EnemyController>();

        // パトロール地点の親を検索
        m_patrolObj = GameObject.Find("EnemyPatrolPoint");
        // パトロールマネージャーを取得
        patrolManager = m_patrolObj.GetComponent<EnemyPatrolManager>();


        // 自身のNavMeshAgentの取得
        enemyNav = gameObject.GetComponent<NavMeshAgent>();

        // 索敵コンポーネントの取得
        m_searchComp = m_searchArea.GetComponent<SearchPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        // エネミーが死亡していない場合
        if(m_enemyCtrl.state != EnemyController.EnemyState.Dead)
        {
            // エネミーがプレイヤーを見つけていた場合、プレイヤーを追尾
            if (m_searchComp.isDetected == true)
            {
                // ターゲット(プレイヤー位置)に自動移動する
                enemyNav.destination = patrolManager.GetPlayerObj().transform.position;
            }
            // 見つけていなかった場合
            else
            {

                Patrol();

            }

            // NavMeshAgentの加速度を移動速度として保管
            moveSpeed = enemyNav.velocity;
        }
        else
        {
            // NavMesh停止
            enemyNav.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            // 移動速度を0に
            moveSpeed = new Vector3(0.0f, 0.0f, 0.0f);
        }

    }

    // エネミーの巡回関数
    private void Patrol()
    {

        // 巡回時間が0以下のとき設定
        if(m_patrolTimer <= 0.0f)
        {
            m_patrolTimer = changeNextPointTimer;
        }

        // パトロールタイマーが更新されたら巡回地点を新規設定
        if(m_patrolTimer == changeNextPointTimer)
        {
            m_nextPatrolPos = Random.Range(0, patrolManager.GetALLPatrolPoint());
        }

        enemyNav.destination = patrolManager.GetPatrolPos(m_nextPatrolPos).position;

        // 巡回時間を減らす
        m_patrolTimer -= Time.deltaTime;
        
    }

}
