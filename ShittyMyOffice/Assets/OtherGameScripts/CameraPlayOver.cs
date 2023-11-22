using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayOver : MonoBehaviour
{
    public GameWinOrOverPanel m_WinUI;

    public void Event_CameraPlayerOver()
    {
        m_WinUI.ShowUI("游戏胜利");
    }
}
