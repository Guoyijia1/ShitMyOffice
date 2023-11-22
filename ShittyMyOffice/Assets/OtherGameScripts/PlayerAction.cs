using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家得行为
public class PlayerAction : MonoBehaviour
{
    private Animator m_Animator;

    private Rigidbody m_Rig;

    private CapsuleCollider m_CapCollider;

    private PlayerFms m_Fsm;

    private PlayerController m_PlayerController;

    private float m_CurTime;

    //被击倒击退力度
    public float m_HitDownPower;

    //记录原始碰撞盒子得高度和Y得值
    private float m_OrgColliderY;
    private float m_orgColliderH;

    private void Start() {
        m_Animator = GetComponent<Animator>();
        
        m_Rig = GetComponent<Rigidbody>();

        m_CapCollider = GetComponent<CapsuleCollider>();
        m_OrgColliderY = m_CapCollider.center.y ;
        m_orgColliderH = m_CapCollider.height;

        m_Fsm = GetComponent<PlayerFms>();

        m_PlayerController = GetComponent<PlayerController>();
    } 

    //进入击倒，击退
    public void EnterHitGoBack(GameObject _target)
    { 
        m_Rig.AddForce((-transform.forward + transform.up) * Time.deltaTime *m_HitDownPower); 
        //玩家失去控制权限
        m_PlayerController.m_IsController = false;
        //改变动画
        m_Animator.SetTrigger("HitGoDown");
        m_Animator.SetBool("JumpDown",true);
    } 

    //被击倒状态结束
    public void Event_HitGoDownOVer()
    {
        //玩家获取控制权
        m_PlayerController.m_IsController = true;
        //状态改变
        m_Fsm.ChangeState(E_State.Idle,null); 
        m_Animator.SetBool("JumpDown",false);
    }

    //向下移动
    public void EnterMoveDown()
    {  

        m_PlayerController.m_IsController = false;
        m_Animator.SetBool("MoveDown",true);
       // m_Rig.AddForce((transform.forward) * Time.deltaTime * 5000); 
        //改变碰撞体
        m_CapCollider.center = new Vector3(m_CapCollider.center.x,0.24f,m_CapCollider.center.z);
        m_CapCollider.height = 0.3f;

    }  

    public void Event_MoveDownOver()
    {
        m_PlayerController.m_IsController = true;
        //碰撞体还原
        m_CapCollider.center = new Vector3(m_CapCollider.center.x,m_OrgColliderY,m_CapCollider.center.z);
        m_CapCollider.height = m_orgColliderH;
        m_Fsm.ChangeState(E_State.Idle,gameObject);
    }

    //攻击
    public void EnterAttack() 
    {    
         m_Animator.SetTrigger("Throw");
    }

    //攻击结束
    public void Event_AttackOver() 
    {
        m_Animator.ResetTrigger("Throw");
        m_Fsm.ChangeState(E_State.Idle,gameObject);
    }
 
}
