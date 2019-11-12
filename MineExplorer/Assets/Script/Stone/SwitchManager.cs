using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchManager : MonoBehaviour
{
    bool[] m_switchOn;
    bool m_clear;
    // Start is called before the first frame update
    void Start()
    {
        m_switchOn = new bool[4];
        for (int i = 0;i< 4; i++)
        {
            m_switchOn[i] = false;
        }
        m_clear = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_clear = m_switchOn[3];//のちに書き換え
        if(m_clear)
        {
            //sceneManagerへ
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("どこか");
            }
            //scenemanager.resalt()的なやつを用意
        }
    }

    public void Applystone()
    {
        for (int i = 0; i < 4; i++) 
        {
            if(m_switchOn[i]==false)
            {
                m_switchOn[i] = true;
                break;
            }            
        }
    }
}
