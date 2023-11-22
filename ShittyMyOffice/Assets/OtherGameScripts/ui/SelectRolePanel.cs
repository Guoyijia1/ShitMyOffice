using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectRolePanel : MonoBehaviour
{
    public Button m_EnterGameBnt;

    public Button m_ReTurn;

    public Button m_LeftA;

    public Button m_RightA;

    public List<GameObject> m_RoleList;
    private bool m_IsMan;
    void Start()
    {
        m_ReTurn.onClick.AddListener(()=>{
            gameObject.SetActive(false);
        });

        m_EnterGameBnt.onClick.AddListener(()=>{
            if(PlayerData.m_RoleId == 0)
            {
                SceneManager.LoadScene("Game1");
            }
            else if(PlayerData.m_RoleId == 1)
            {
                SceneManager.LoadScene("Game");
            } 
        }); 
    } 

    private void OnEnable() {
        PlayerData.m_RoleId = 0;
        m_RoleList[0].SetActive(true);
        m_RoleList[1].SetActive(false);
        m_IsMan = false;
    }

    //换角色
    public void ChangeRole() 
    {
        m_IsMan = !m_IsMan;
        if(m_IsMan) //男
        {
            PlayerData.m_RoleId = 1;
            m_RoleList[0].SetActive(false);
            m_RoleList[1].SetActive(true);
        }
        else        //女
        {
            PlayerData.m_RoleId = 0;
            m_RoleList[0].SetActive(true);
            m_RoleList[1].SetActive(false);
        } 
    }
    
}
