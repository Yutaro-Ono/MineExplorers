//----------------------------------------------------//
// エネミーの索敵処理
//                                   2019 Yutaro Ono.
//---------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour
{
    // プレイヤーを発見したかどうか
    public bool isDetected;

    // 索敵範囲のコライダー
    private SphereCollider m_searchArea;

    // Start is called before the first frame update
    void Start()
    {
        isDetected = false;

        m_searchArea = GetComponent<SphereCollider>();
    }

    // プレイヤーを発見した
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isDetected = true;
        }
    }

    // プレイヤーを見失った
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //isDetected = false;
        }
    }
}
