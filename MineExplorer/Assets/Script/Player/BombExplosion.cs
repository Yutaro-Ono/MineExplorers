using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    GameObject m_particleResources;
    [SerializeField]
    GameObject m_ParticlePrefub;
    void Start()
    {
        m_particleResources = (GameObject)Resources.Load("Particle/Explosion2");
    }
    private void OnTriggerEnter(Collider other)
    {
        m_ParticlePrefub = Instantiate(m_particleResources, this.transform.position, Quaternion.identity);
        //パーティクル生成
        Destroy(this);
    }
}
