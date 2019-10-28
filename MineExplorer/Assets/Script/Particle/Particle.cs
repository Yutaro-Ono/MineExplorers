﻿//----------------------------------------------------//
// 再生が終わったらパーティクルを削除する
//                                   2019 sora hanada
//---------------------------------------------------//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    ParticleSystem m_particleSystem;
    //消す基準となるパーティクル
    [SerializeField]
    GameObject m_particle;
    
    void Start()
    {

        m_particle = GameObject.Find("Shockwave");

        m_particleSystem = m_particle.GetComponent<ParticleSystem>();

        if(m_particleSystem == null)
        {
            Debug.Log("パーティクル:ParticleSystemコンポーネント取得失敗");
        }
    }
    void Update()
    {
        if (m_particleSystem.IsAlive() == false) 
        {
            Destroy(gameObject);
        }
    }
}
