using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuPanel : MonoBehaviour
{
    public Button m_ExitBtn;

    public Button m_StartBtn;

  
    void Start()
    {
        m_ExitBtn.onClick.AddListener(()=>{
            Application.Quit();
        });

        m_StartBtn.onClick.AddListener(()=>{
            SceneManager.LoadScene("Game"); 
        });
    }

     
}
