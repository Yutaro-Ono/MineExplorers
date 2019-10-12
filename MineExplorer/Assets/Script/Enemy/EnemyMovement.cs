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
    private NavMeshAgent myNav;

    // ターゲティングするプレイヤーオブジェクト格納用
    private GameObject tagPlayer;

    // Start is called before the first frame update
    void Start()
    {
        // 自身のNavMeshAgentの取得
        myNav = gameObject.GetComponent<NavMeshAgent>();

        // プレイヤーオブジェクトを取得
        tagPlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // ターゲット(プレイヤー位置)に自動移動する
        myNav.destination = tagPlayer.transform.position;
    }

    
}
