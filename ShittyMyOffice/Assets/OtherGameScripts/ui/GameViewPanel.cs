using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameViewPanel : MonoBehaviour
{
    public Text m_HpText;

    public Text m_EnemyNums;

    //更新UI
    public void UpdateUi(CharacterState _state)
    {
        if(m_HpText!=null)
            m_HpText.text = _state.m_CurHp.ToString();
        if(m_EnemyNums!=null)
            m_EnemyNums.text = _state.m_KillEnemyNums.ToString();
    }

    
}
