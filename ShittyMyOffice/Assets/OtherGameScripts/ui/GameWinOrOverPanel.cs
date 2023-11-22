using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameWinOrOverPanel : MonoBehaviour
{
    public Button m_ExitBtn;

    public Button m_ReStartBtn;

    //野兽击杀次数
    public Text  m_YeShouKillNumsT;

    //野兽出现次数
    public Text m_YeShouShowNumsT;

    public Text m_Str;

    //分子 
    public InputField m_FenZiField;

    //分母
    public InputField m_FenMuField;

    //结果
    public Text m_ResultT;

    void Start()
    {
        //m_FenZiField.text = "0";
        //m_FenMuField.text = "0";
        
        //m_ExitBtn.onClick.AddListener(()=>{
        //    SceneManager.LoadScene("Menu");
        //}) ;  

        m_ReStartBtn.onClick.AddListener(()=>{
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        });
    }

    //计算结果
    public float Result() 
    {
        float fenzi  = Convert.ToSingle(m_FenZiField.text);
        float fenmu =  Convert.ToSingle(m_FenMuField.text);
        
        return fenzi / fenmu ;
    }
     
    void Update()
    {
        //m_YeShouKillNumsT.text = PlayerData.m_KillNums.ToString();
        //m_YeShouShowNumsT.text =  PlayerData.m_ShowNums.ToString();

        ////计算结果
        //m_ResultT.text = Result().ToString();
    }

    public void ShowUI(string _tile)
    {
        m_Str.text = _tile;
        gameObject.SetActive(true);
    }
}
