using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    GameObject m_particleResources;
    [SerializeField]
    GameObject m_particlePrefub;
    bool m_explosion = false;
    void Start()
    {
        m_particleResources = (GameObject)Resources.Load("Particle/Explosion 2");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (m_explosion == false)
            {
                m_explosion = true;
                //パーティクル生成
                m_particlePrefub = Instantiate(m_particleResources, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
