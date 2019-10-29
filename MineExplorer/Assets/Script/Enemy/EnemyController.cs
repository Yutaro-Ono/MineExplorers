//--------------------------------------------------------------------------//
// エネミーのコントロール(主にステート関連をここで編集します)
//                                                      2019 Yutaro Ono.
//-------------------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // エネミーのステート
    public enum EnemyState
    {
        Idle,
        Walk,
        Run,
        Attack,
        Dead
    }
    // ステート格納用
    public EnemyState state;

    // EnemyAnimationControllerを取得
    private EnemyAnimationController m_animCtrl;

    // エネミーの移動(NavMeshAgent取得)
    EnemyMovement m_move;

    // エネミーの攻撃開始エリア
    [SerializeField] GameObject m_attackArea;

    // エネミーの攻撃判定コンポーネント取得
    EnemyAttack m_attack;

    // エネミーの当たり判定ボックス
    private BoxCollider m_boxColl;

    void Start()
    {
        // ステートを待機状態にしておく
        state = EnemyState.Idle;

        // EnemyAnimationControllerコンポーネントの取得
        m_animCtrl = GetComponent<EnemyAnimationController>();
        // EnemyMovementコンポーネントの取得
        m_move = GetComponent<EnemyMovement>();
        // EnemyAttackコンポーネントの取得
        m_attack = m_attackArea.GetComponent<EnemyAttack>();

        // エネミー当たり判定取得
        m_boxColl = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if(state != EnemyState.Dead)
        {
            // 移動速度ベクトルのxとzの値が0より上だった時、移動していることを示す " Run " に設定
            if (m_move.moveSpeed.x != Vector3.zero.x || m_move.moveSpeed.z != Vector3.zero.z)
            {
                state = EnemyState.Run;
            }

            // 攻撃フラグがオンの時、攻撃していることを示す " Attack " に設定
            if (m_attack.isAttack == true)
            {
                state = EnemyState.Attack;
            }

            // スピードが0なら待機状態
            if (m_move.moveSpeed == Vector3.zero)
            {
                state = EnemyState.Idle;
            }
        }


    }

    // 地雷の爆風に当たった時の処理
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BombExplosion")
        {
            // 死亡状態にする
            state = EnemyState.Dead;
        }
    }

    // 攻撃フラグをオフ
    public void AttackFlgOff()
    {
        m_animCtrl.AttackEnd();
        m_attack.isAttack = false;

    }
}
