//-----------------------------------------------------------------//
// エネミーのアニメーションコントロール
//                                          2019 Yutaro Ono.
//----------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{

    // EnemyController取得
    private EnemyController m_enemyCtrl;

    // Animatorコンポーネント取得
    private Animator m_anim;

    // Start is called before the first frame update
    void Start()
    {
        m_enemyCtrl = GetComponent<EnemyController>();

        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Enemyコントローラーのステートが " Run " 状態だった時、走るアニメーションのフラグをon
        if(m_enemyCtrl.state == EnemyController.EnemyState.Run)
        {
            m_anim.SetBool("Run Forward", true);
        }

        // 待機モーション
        if(m_enemyCtrl.state == EnemyController.EnemyState.Idle)
        {
            m_anim.SetBool("Run Forward", false);
        }

        // 攻撃モーション
        if(m_enemyCtrl.state == EnemyController.EnemyState.Attack)
        {
            m_anim.SetBool("Run Forward", false);
            m_anim.SetTrigger("Attack 02");
        }

        // 死亡モーション
        if(m_enemyCtrl.state == EnemyController.EnemyState.Dead)
        {
            m_anim.SetTrigger("Die");
        }
    }
}
