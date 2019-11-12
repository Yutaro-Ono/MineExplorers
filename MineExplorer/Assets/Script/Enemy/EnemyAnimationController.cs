//-----------------------------------------------------------------//
// エネミーのアニメーションコントロール
//                                          2019 Yutaro Ono.
//----------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{

    // EnemyController取得用
    private EnemyController m_enemyCtrl;

    // Animatorコンポーネント取得用
    private Animator m_anim;

    // Start is called before the first frame update
    void Start()
    {
        m_enemyCtrl = GetComponent<EnemyController>();

        // Animatorコンポーネント取得
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
            m_anim.SetBool("Attack", true);
        }

        // 死亡モーション
        if(m_enemyCtrl.state == EnemyController.EnemyState.Dead)
        {
            m_anim.SetBool("Run Forward", false);
            m_anim.SetBool("Attack", false);

            m_anim.SetTrigger("Die");
        }
    }

    public void AttackEnd()
    {
        m_anim.SetBool("RunForward", true);
        
        m_anim.SetBool("Attack", false);
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
