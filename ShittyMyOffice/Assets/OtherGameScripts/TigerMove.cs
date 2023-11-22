using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerMove : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;

    private bool m_GO;

    private bool m_Back;

    private void Start()
    {
        Invoke("B", 1.5f);
    }

    public void B()
    {
        m_Back = true;
        m_GO = false;
    }

    public void F()
    {
        m_Back = false;
        m_GO = true;
    }

    //向前跑
    public void GoHead()
    {
        transform.position = Vector3.Lerp(transform.position, pos1.position, 0.01f);
    }

    //向后跑
    public void GoBack()
    {
        transform.position = Vector3.Lerp(transform.position, pos2.position, 0.01f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            m_GO = true;
            m_Back = false;
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            m_Back = true;
            m_GO = false;
        }

        if(m_GO)
        {
            GoHead();
        }

        if(m_Back)
        {
            GoBack();
        } 
    }

   
}
