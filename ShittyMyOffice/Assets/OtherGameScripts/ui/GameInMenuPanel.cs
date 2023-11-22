using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInMenuPanel : MonoBehaviour
{
    public Button m_ExitBt;
   
    void Start()
    {
        
        m_ExitBt.onClick.AddListener(()=>{
            SceneManager.LoadScene("Menu");
        });
    }

    private void OnEnable() {
        Time.timeScale = 0;
    }

    private void OnDisable() {
        Time.timeScale = 1;
    }
 
}
