using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//选择武器界面
public class SelectWeanponPanel : MonoBehaviour
{
    public List<Toggle> m_Toggles; 
    
    public Button m_OKBtn;

    public GameObject m_SelectRolePlane;

    private void Start() {
        m_Toggles[0].isOn = true;

        m_OKBtn.onClick.AddListener(()=>{
            if(IsSeclectWeapon())
            {
                Time.timeScale = 1;
                m_SelectRolePlane.SetActive(true);
                gameObject.SetActive(false);
               // SceneManager.LoadScene("Game");
            }
            else
            {
                Debug.Log("请选择武器");
            }
        });
    }

    void Update()
    {
        for(int i=0; i<m_Toggles.Count;i++)
        {
            if(m_Toggles[i].isOn)
            {
                PlayerData.m_WeaponId = i;
            }
        }

        Debug.Log("WeaponId:" +  PlayerData.m_WeaponId);
    }

    //是否选中武器
    public bool IsSeclectWeapon() 
    {
        for(int i=0;i<m_Toggles.Count;i++)
        {
            if(m_Toggles[i].isOn)
                return true;
        }
        return false;
    }

}
