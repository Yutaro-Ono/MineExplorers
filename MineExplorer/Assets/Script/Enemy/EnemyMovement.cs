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
    public Vector3 moveSpeed;


    // ターゲティングするプレイヤーオブジェクト格納用
    private GameObject tagPlayer;



    // Start is called before the first frame update
    void Start()
    {
        // 自身のNavMeshAgentの取得
        enemyNav = gameObject.GetComponent<NavMeshAgent>();

        // プレイヤーオブジェクトを取得
        tagPlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // ターゲット(プレイヤー位置)に自動移動する
        enemyNav.destination = tagPlayer.transform.position;

        // NavMeshAgentの加速度を移動速度として保管
        moveSpeed = enemyNav.velocity;
    }

}
