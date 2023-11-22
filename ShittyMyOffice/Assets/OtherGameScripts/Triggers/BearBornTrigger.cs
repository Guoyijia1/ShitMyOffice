using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ܳ�û������
public class BearBornTrigger : MonoBehaviour
{ 
    //��Դ
    public GameObject m_Res;

    private int m_type;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            int type = Random.Range(0, 2);
            
            m_type = type;

            if (m_type == 0)
            {
                GameObject bear = GameObject.Instantiate(m_Res);
                Vector3 Pos = transform.TransformPoint(Vector3.forward * 5);
                Pos.x = -8;
                bear.transform.position = Pos;

                PlayerData.m_ShowNums++;
            }
            else if(m_type == 1)
            {
                GameObject bear = GameObject.Instantiate(m_Res);
                Vector3 Pos = transform.TransformPoint(Vector3.forward * 5);
                Pos.x = 8;
                bear.transform.position = Pos;
                PlayerData.m_ShowNums++;
            } 

        }
    }
}
