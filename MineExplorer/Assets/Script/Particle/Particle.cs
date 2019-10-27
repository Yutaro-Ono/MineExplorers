using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    ParticleSystem m_ParticleSystem;
    //消す基準となるパーティクル
    [SerializeField]
    GameObject m_Particle;
    
    void Start()
    {
        m_ParticleSystem = m_Particle.GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (m_ParticleSystem.isStopped == true) 
        {
            Destroy(this);
        }
    }
}
