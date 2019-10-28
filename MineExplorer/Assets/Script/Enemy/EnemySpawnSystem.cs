//-------------------------------------------------------------------------//
// エネミーをゲーム中、動的に生成するスポーンスクリプト
//               ※スポーン地点の親オブジェクトにアタッチします
//                                                       2019 Yutaro Ono.
//------------------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    // エネミーのタイプ
    public enum ENEMY_TYPE
    {
        ENEMY_A = 0,
        ENEMY_B,
        ALL_ENEMY
    }

    // スポーン地点オブジェクトの座標
    [SerializeField] Transform[] m_spawnPoint;
    // スポーン地点の総数
    private int m_allPoint;


    // スポーンさせるエネミープレハブ(エネミーの種類分確保)
    [SerializeField] GameObject[] m_enemyPrefab;
    // スポーンさせたエネミー格納
    [SerializeField] GameObject m_enemyObj;


    // 現在フィールドにいるエネミーの総数
    private int m_nowEnemy;
    // エネミーの最大出現数
    [SerializeField] int m_maxEnemy;


    // エネミー出現のトリガーとなるタイマー
    [SerializeField] float m_spawnTimer = 0.2f;
    // ループ中、時間をカウントするタイマー
    [SerializeField] float m_countTimer;


    // 登場エフェクト
    GameObject explosionPrefab;
    GameObject explosionObj;
    // エフェクトを使用するかどうか
    public bool isUseEffect;


    // Start is called before the first frame update
    void Start()
    {
        // エネミーの種類分配列を確保
        m_enemyPrefab = new GameObject[(int)ENEMY_TYPE.ALL_ENEMY];

        // エネミーのプレハブをResourcesフォルダから全種類取得
        for (int i = 0; i < (int)ENEMY_TYPE.ALL_ENEMY; i++)
        {
            m_enemyPrefab[i] = (GameObject)Resources.Load("Enemy/Enemy" + (i + 1));
        }


        // スポーン地点の親オブジェクトを取得
        GameObject spawnParent = GameObject.Find("EnemySpawnPoint");
        if (spawnParent == null)
        {
            Debug.Log("エネミー:スポーン地点の親オブジェクトが取得できてないよ！");
        }

        // スポーン地点がいくつあるかを保存
        m_allPoint = spawnParent.transform.childCount;
        // スポーン地点分の配列を確保
        m_spawnPoint = new Transform[m_allPoint];

        // スポーン地点(子)の取得
        for (int i = 0; i < m_allPoint; i++)
        {
            m_spawnPoint[i] = spawnParent.transform.Find("point" + (i + 1));
        }


        // エフェクトプレハブをResourcesフォルダから取得
        explosionPrefab = (GameObject)Resources.Load("Particle/BombExplosion");


        m_nowEnemy = 0;
        m_countTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        // 8秒ごとかつエネミーの出現数が最大に達していない場合
        if(m_countTimer > m_spawnTimer && m_nowEnemy < m_maxEnemy)
        {
            // ランダムなポイントからエネミーAを出現させる
            SpawnEnemy(Random.Range(0, (int)ENEMY_TYPE.ALL_ENEMY), Random.Range(0, m_allPoint));

            // エネミーの出現数を更新
            m_nowEnemy++;
            // カウント用タイマーを初期化
            m_countTimer = 0.0f;
        }

        if(m_nowEnemy < m_maxEnemy)
        {
            // デルタタイムを取得
            m_countTimer += Time.deltaTime;
        }

    }

    // エネミーをinstantiateする関数(第1引数:生成するエネミーのタイプ, 第2引数:スポーン地点の指定)
    void SpawnEnemy(int in_type, int in_spawnPoint)
    {
        m_enemyObj = Instantiate( m_enemyPrefab[(int)in_type], 
                                  m_spawnPoint[in_spawnPoint].transform.position, 
                                  Quaternion.identity);

        // エフェクトの生成
        if(isUseEffect == true)
        {
            explosionObj = Instantiate(explosionPrefab, m_spawnPoint[in_spawnPoint].transform.position, Quaternion.identity);
        }

    }

    // 出現中エネミー数ゲッター
    int GetNowEnemy()
    {
        return m_nowEnemy;
    }
}
