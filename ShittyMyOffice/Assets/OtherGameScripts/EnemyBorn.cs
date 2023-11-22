using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBorn : MonoBehaviour
{
    public List<GameObject> m_Res;

    private float m_CurTime;

    public float m_Time; 
      
    void Update()
    {
        m_CurTime += Time.deltaTime;
        if(m_CurTime >= m_Time)
        {
            m_CurTime = 0;
            Vector3 pos = new Vector3(transform.position.x,0,transform.position.z); 
            GameObject.Instantiate(m_Res[0],pos,Quaternion.identity);
            PlayerData.m_ShowNums++;
        }
    }
}
