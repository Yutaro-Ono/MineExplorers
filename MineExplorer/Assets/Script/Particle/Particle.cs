using System.Collections;
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
        m_particleSystem = m_particle.GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (m_particleSystem.isStopped == true) 
        {
            Destroy(this.gameObject);
        }
    }
}
