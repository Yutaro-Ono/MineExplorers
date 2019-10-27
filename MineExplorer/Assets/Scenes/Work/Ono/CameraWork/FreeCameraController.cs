// デバッグカメラ
//          2019 Yutaro Ono.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    Animator cameraAnim;

    // 移動(1:前方, -1:後方移動)
    private float m_forward;
    // 回転(1:右回転, -1:左回転)
    private float m_rotation;

    // Start is called before the first frame update
    void Start()
    {
        cameraAnim = this.GetComponent<Animator>();
        m_forward = 0.0f;
        m_rotation = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        // 移動処理
        if(Input.GetKey(KeyCode.W) && m_forward <= 1.0f)
        {
            m_forward = 1.0f;
        }
        if (Input.GetKey(KeyCode.S) && m_forward >= -1.0f)
        {
            m_forward = -1.0f;
        }

        // 回転処理
        if (Input.GetKey(KeyCode.D) && m_rotation <= 1.0f)
        {
            m_rotation = 1.0f;
        }
        if (Input.GetKey(KeyCode.A) && m_forward >= -1.0f)
        {
            m_rotation = -1.0f;
        }


        // アニメーションのFloat値を更新
        cameraAnim.SetFloat("Z_Move", m_forward);
        cameraAnim.SetFloat("Y_Rotation", m_rotation);

        // アニメーションの更新後、初期化
        m_forward = 0;
        m_rotation = 0;
    }
}
