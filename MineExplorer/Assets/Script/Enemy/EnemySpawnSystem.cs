// エネミーをゲーム中、動的に生成する
//            2019 Yutaro Ono.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    // スポーンさせるエネミー格納
    [SerializeField] GameObject[] m_enemyObj;

    // 現在フィールドにいるエネミーの総数
    public int nowEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy(int in_enemyType, int in_spawnPoint)
    {

    }
}
