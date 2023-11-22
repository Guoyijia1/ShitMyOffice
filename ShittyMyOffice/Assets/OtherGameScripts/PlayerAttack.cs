using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//攻击
public class PlayerAttack : MonoBehaviour
{
    //石头资源
    public GameObject m_RockRes;
    //弓箭
    public GameObject m_ArrowRes;

    //当前武器
    public GameObject m_CurWeapon;
    //飞刀
    public GameObject m_FeiDaoRes;

    public Transform m_RokcPos;

    public float m_ThrowPower;
    
    private PlayerFms m_Fsm;

    
    private RaycastHit hitinfo;  
    void Start()
    {  
        m_Fsm = GetComponent<PlayerFms>();

        //武器初始化
        switch(PlayerData.m_WeaponId)
        {
            case 0: //石头
            m_CurWeapon = m_RockRes;
            break;
            case 1: //弓箭
            m_CurWeapon = m_ArrowRes;
            break;
            case 2: //飞刀
            m_CurWeapon = m_FeiDaoRes;
            break;
        }
    }

    //记录按下时间
    private float m_PressTime;
    private bool m_IsPress;

    void Update()
    {   
        //if(Input.GetMouseButtonDown(0))
        //{
        //    m_IsPress = true; 
        //}

        //if(Input.GetMouseButtonUp(0))
        //{
        //     m_IsPress = false;
        //     if(m_PressTime<=0.1f)
        //     {
        //        ThrowRock() ;
        //        GetComponent<PlayerSoundMgr>().TrowRock(); 
        //     }

        //    m_PressTime = 0;
        //}

        //if(m_IsPress)
        //{
        //    m_PressTime+=Time.deltaTime; 
        //}
    }

  
}
