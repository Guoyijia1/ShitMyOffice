using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum E_AIState
{
    Attack,
    Idle,
    Move,

    Hit,

    Noem,
    Die
}
public class AiBase : MonoBehaviour
{
    //目标
    public GameObject m_Target;

    public E_AIState m_CurState;

    public float m_MoveSpeed;
    public float m_AttackRange;
    public float m_AttackRate;
    private float  m_CurTime;

    private Animator m_Animator; 

    void Start()
    {
        m_CurState = E_AIState.Move;
        m_Animator = GetComponent<Animator>(); 
        m_Animator.SetBool("Run",true);

        m_Target = GameObject.Find("StartPos");

        //播放声音
        GetComponent<AudioSource>().Play();
    } 
    
    void Update()
    {
        switch(m_CurState)
        {
            case E_AIState.Move:
                
                Vector3 dir = (m_Target.transform.position -  transform.position).normalized;
                dir.y = 0;
                transform.rotation = Quaternion.LookRotation(dir);
                transform.Translate(Vector3.forward * Time.deltaTime * m_MoveSpeed);
             

                m_Animator.SetBool("Run",true);
               
                break;
            case E_AIState.Attack:
                // Vector3 dir = (m_Target.transform.position - transform.position).normalized;
                // dir.y = 0;
                // transform.rotation = Quaternion.LookRotation(dir );
                // m_CurTime+=Time.deltaTime;
                // if(m_CurTime>=m_AttackRate)
                // {
                //      m_Animator.SetTrigger("Attack");
                //     m_CurTime = 0;
                // }

                // //在攻击范围外
                // if(!IsRange(m_AttackRange))
                // {
                //     m_Animator.ResetTrigger("Attack");
                //     m_CurState = E_AIState.Move;
                //     m_Animator.SetBool("Run",true);
                // }
                
                // m_Animator.SetBool("Run",false);
                //  m_Agent.isStopped = true;
                break;
            case E_AIState.Hit: 
                m_Animator.SetBool("Run",false);
                break;
            case E_AIState.Die:
                break;
        }
    }

    public bool IsRange(float _dis)
    {
        float dis = Vector3.Distance(transform.position,m_Target.transform.position);
        if(dis<_dis)
        {
            return true;
        }

        return false;
    }

    //被打完
    public void EventHiDamgeOver()
    {
    
        m_CurState = E_AIState.Move;
    }
}
