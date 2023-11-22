using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum E_State
{
    None,

    Idle,   //待机

    HitGoBack, //击退，击倒状态

    MoveDown, //下移

    Attack  //攻击
}

//状态
public class PlayerFms : MonoBehaviour
{
    //当前状态
    public E_State  m_CurState; 

    //玩家行为
    private PlayerAction m_PlayerAction;

    private void Start() {
        m_PlayerAction = GetComponent<PlayerAction>();
        m_CurState = E_State.Idle;
    }
    
    //改变状态
    public void ChangeState(E_State _nextState,GameObject _obj)
    {
        if(m_PlayerAction == null)
            return;

        switch(m_CurState)
        {
            case E_State.None:  
                break;
            case E_State.HitGoBack: 
                break;
            case E_State.MoveDown:
                break;
            case E_State.Attack:
                break;
        } 

        m_CurState = _nextState;

        switch(m_CurState)
        {
            case E_State.None:

                break;
            case E_State.HitGoBack:
                m_PlayerAction.EnterHitGoBack(_obj);
                break;
            case E_State.MoveDown:
                m_PlayerAction.EnterMoveDown();
                break;
            case E_State.Attack:
                m_PlayerAction.EnterAttack();
                break;
        } 
    } 

    private void Update() 
    {
        switch(m_CurState)
        {
            case E_State.HitGoBack: 
            break;
            case E_State.Idle:
                
            break;
        }
    }
}
