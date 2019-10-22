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

    // 巡回する地点のtransform(EnemyPatrolPointの子オブジェクト座標)
    [SerializeField] private Transform[] m_patrolPos;
    // 目的地点の総数
    private int m_allPoint;
    // 次回目的地設定用ID
    private int m_nextPatrolPos = 0;


    // ターゲティングするプレイヤーオブジェクト格納用
    private GameObject tagPlayer;

    // エネミーの索敵範囲オブジェクト
    [SerializeField] GameObject m_searchArea;
    // エネミーの索敵処理コンポーネント
    private SearchPlayer m_searchComp;

    // Start is called before the first frame update
    void Start()
    {
        m_patrolTimer = 0.0f;

        // 巡回地点の親オブジェクトを取得
        GameObject patrolPoint = GameObject.Find("EnemyPatrolPoint");
        // 巡回地点がいくつあるかを保存
        m_allPoint = patrolPoint.transform.childCount;
        // 巡回地点分の配列を確保
        m_patrolPos = new Transform[m_allPoint];
        // 巡回地点(子)の取得
        for(int i = 0; i > m_allPoint; i++)
        {
            m_patrolPos[i] = patrolPoint.transform.FindChild("point" + (i + 1));
        }

        // 自身のNavMeshAgentの取得
        enemyNav = gameObject.GetComponent<NavMeshAgent>();

        // プレイヤーオブジェクトを取得
        tagPlayer = GameObject.Find("Player");

        // 索敵コンポーネントの取得
        m_searchComp = m_searchArea.GetComponent<SearchPlayer>();
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
            //// NavMesh停止
            //enemyNav.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            //// 移動速度を0に
            //moveSpeed = new Vector3(0.0f, 0.0f, 0.0f);
            Patrol();

        }


    }

    // エネミーの巡回関数
    private void Patrol()
    {
        float timer = 5.0f;

        // 巡回時間が0以下のとき設定
        if(m_patrolTimer <= 0.0f)
        {
            m_patrolTimer = timer;
        }

        // パトロールタイマーが更新されたら巡回地点を新規設定
        if(m_patrolTimer == timer)
        {
            m_nextPatrolPos = Random.Range(0, m_allPoint);

        }

        enemyNav.destination = m_patrolPos[m_nextPatrolPos].position;

        // 巡回時間を減らす
        m_patrolTimer -= Time.deltaTime;
        
    }

}
