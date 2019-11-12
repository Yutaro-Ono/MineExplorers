using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyStone : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Stone")
        {
            other.gameObject.transform.position =
                new Vector3(this.transform.position.x
                , this.transform.position.y + 0.5f
                , this.transform.position.z);
            Debug.Log("はめ込み完了");
        }
    }
}
