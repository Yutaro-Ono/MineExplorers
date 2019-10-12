using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingCamera : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //y10,z-10
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 10, Player.transform.position.z - 10);
    }
}
