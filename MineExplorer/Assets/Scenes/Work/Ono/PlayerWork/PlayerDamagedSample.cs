using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedSample : MonoBehaviour
{
    [SerializeField] BoxCollider m_col;

    // Start is called before the first frame update
    void Start()
    {
        m_col = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyAttack")
        {
            Debug.Log("プレイヤー : 痛っ！！");
        }
    }
}
