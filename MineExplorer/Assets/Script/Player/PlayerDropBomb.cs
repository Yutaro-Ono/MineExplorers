using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerDropBomb : MonoBehaviour
{
    //ロードされるオブジェ
    GameObject m_BombResources;
    //実際に置かれるプレハブ
    [SerializeField]
    GameObject m_BombPrefab;
    //置くところ
    [SerializeField]
    GameObject m_CreatBombPoint;
    Player m_player0;
    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトロード
        m_BombResources = (GameObject)Resources.Load("Bomb/at_mine_LOD4");
    }

    // Update is called once per frame
    void Update()
    {
        //ボム（地雷）の位置調整、
        //if (m_player0.GetButtonDown("PutMine"))
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_BombPrefab = Instantiate(m_BombResources, m_CreatBombPoint.transform.position,Quaternion.identity);
        }
    }
}
