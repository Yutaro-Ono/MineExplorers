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

    // 攻撃判定用のコライダー
    [SerializeField] GameObject m_attackPoint;

    // Start is called before the first frame update
    void Start()
    {
        isAttack = false;

        // 攻撃当たり判定についてはオフにしておく
        m_attackPoint.SetActive(false);
    }

    void Update()
    {

        // 攻撃フラグがたったら当たり判定をオン
        if(isAttack == true)
        {
            m_attackPoint.SetActive(true);
        }
        else
        {
            m_attackPoint.SetActive(false);
        }

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
