//-------------------------------------------------------------------//
// エネミーパトロールマネージャー(巡回地点座標, プレイヤー座標の一元管理)
//                 2019 Yutaro Ono.
//------------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolManager : MonoBehaviour
{
    // ターゲティングするプレイヤーオブジェクト格納用
    private GameObject m_tagPlayer;

    // 巡回する地点のtransform(EnemyPatrolPointの子オブジェクト座標)
    [SerializeField] private Transform[] m_patrolPos;
    // 巡回地点の総数
    [SerializeField] int m_allPatrolPoint;


    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーオブジェクトを取得
        m_tagPlayer = GameObject.Find("Player");

        // 巡回地点がいくつあるかを保存
        m_allPatrolPoint = transform.childCount;
        // 巡回地点分の配列を確保
        m_patrolPos = new Transform[m_allPatrolPoint];
        // 巡回地点(子)の取得
        for (int i = 0; i < m_allPatrolPoint; i++)
        {
            m_patrolPos[i] = transform.Find("point" + (i + 1));

            if (m_patrolPos[i] == null)
            {
                Debug.Log("エネミー:巡回地点" + (i + 1) + "が取得できていないよ！");
            }
        }
    }

    // プレイヤーオブジェクト情報を返す
    public GameObject GetPlayerObj()
    {
        return m_tagPlayer;
    }

    // 巡回地点の総数を返す
    public int GetALLPatrolPoint()
    {
        return m_allPatrolPoint;
    }

    // 指定した引数番目の巡回地点を返す
    public Transform GetPatrolPos(int in_pointNum)
    {
        return m_patrolPos[in_pointNum];
    }
}
