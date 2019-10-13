//----------------------------------------------------//
// エネミーの攻撃範囲と攻撃フラグの管理
//                                   2019 Yutaro Ono.
//---------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // 攻撃したかどうかのフラグ
    public bool isAttack;

    // 攻撃判定用のサーチエリア
    // private SphereCollider m_attackArea;

    // Start is called before the first frame update
    void Start()
    {
        isAttack = false;

        // m_attackArea = GetComponent<SphereCollider>();
    }

    // プレイヤーとの衝突判定
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isAttack = true;
        }
    }

    // プレイヤーから離れたら
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isAttack = false;
        }
    }
}
