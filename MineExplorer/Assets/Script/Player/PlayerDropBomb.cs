//----------------------------------------------------//
// 爆弾を置く
//                                   2019 sora hanada
//---------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerDropBomb : MonoBehaviour
{
    //ロードされるオブジェ
    GameObject m_bombResources;
    //実際に置かれるプレハブ
    [SerializeField]
    GameObject m_bombPrefab;
    //置くところ
    Transform m_creatBombPoint;
    Player m_player0;

    // Start is called before the first frame update
    void Start()
    {
        m_creatBombPoint = transform.Find("CreateBombPoint");
        //オブジェクトロード
        m_bombResources = (GameObject)Resources.Load("Bomb/at_mine_LOD5");
    }

    // Update is called once per frame
    void Update()
    {
        //ボム（地雷）の位置調整、
        //if (m_player0.GetButtonDown("PutMine"))
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_bombPrefab = Instantiate(m_bombResources, m_creatBombPoint.transform.position, Quaternion.identity);
        }
    }
}
