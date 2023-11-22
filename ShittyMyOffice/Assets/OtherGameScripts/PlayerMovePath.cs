using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//玩家移动的路线
public class PlayerMovePath : MonoBehaviour
{
    //移动得位置
    //0左 1右边 2中
    private int m_MovePosType;
    private int m_CurMovePosTyp;

    //左中右位置
    public Transform m_LeftPos;
    public Transform m_MidPos;
    public Transform m_RightPos;

    //路径点
    public List<Transform> m_Paths = new List<Transform>();

    public Transform m_PathRoot; 

    private Animator m_Animator;

    public int m_Index;

    //移動速度
    public float  m_MoveSpeed;  

    //是否停止运动
    private bool m_IsStopMove;

    public List<GameObject> m_MosnterRush;

    public   GameWinOrOverPanel m_GameOverUI;
    public GameObject m_GaemFirstWinOrOverUI;

    public AudioClip m_GameOverClip;
    public AudioSource m_BGM;

    //是否左右移动
    public bool m_IsLeftRightMove;

    void Start()
    {
        m_Animator = GetComponent<Animator>();

        for(int i=0;i<m_PathRoot.childCount;i++)
        {
            m_Paths.Add(m_PathRoot.GetChild(i));
        }   

        m_Animator.SetBool("Run",true);

        //当前移动位置 
        m_CurMovePosTyp = 2;
        m_MovePosType = 2;

        m_IsLeftRightMove = true;
    } 
    
    void Update()
    {
        if(m_IsStopMove)
            return;

        if(IsReach())
        {
            m_Index++; 

            if(m_Index>=m_Paths.Count)
            {
                m_Index = m_Paths.Count-1;
            }
        }   
        
        if(Input.GetKeyDown(KeyCode.A))
        { 
            if (m_CurMovePosTyp == 2)
            {
                m_MovePosType = 0;
                m_CurMovePosTyp = m_MovePosType;
            }
            //右边
            else if (m_CurMovePosTyp == 1)
            {
                m_MovePosType = 2;
                m_CurMovePosTyp = m_MovePosType;
            } 
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            //中间
            if (m_CurMovePosTyp == 2)
            {
                m_MovePosType = 1;
                m_CurMovePosTyp = m_MovePosType;
            }
            //左边
            else if (m_CurMovePosTyp == 0)
            {
                m_MovePosType = 2;
                m_CurMovePosTyp = m_MovePosType;
            }
        }

        //移动
        transform.Translate(Vector3.forward * Time.deltaTime * m_MoveSpeed);

        if(m_IsLeftRightMove)
        {
            Vector3 tpmPos = new Vector3(0, transform.position.y, transform.position.z);
            //左中右移动
            if (m_MovePosType == 0) //左边
            {
                tpmPos.x = Mathf.Lerp(transform.position.x, m_LeftPos.position.x, 0.1f);
            }
            else if (m_MovePosType == 2) //中
            {
                tpmPos.x = Mathf.Lerp(transform.position.x, m_MidPos.position.x, 0.1f);
            }
            else if (m_MovePosType == 1) //右
            {
                tpmPos.x = Mathf.Lerp(transform.position.x, m_RightPos.position.x, 0.1f);
            }

            transform.position = tpmPos;
        } 
    }

    public bool IsReach() 
    {   
         
        float dis = Vector3.Distance(transform.position, m_Paths[m_Index].position);
       
        if(dis <= 0.5f)
            return true;
        return false;
    }

    //胜利
    public void Win() 
    { 
        m_IsStopMove = true;
        m_Animator.SetBool("Run",false);
        m_Animator.SetBool("Win",true);
        StopRushMonster();
        Invoke("PlayCamera",3);
    }

    //失败
    public void Over()
    {
        
        m_IsStopMove = true;
        m_Animator.SetBool("Run",false);
        m_Animator.SetBool("Die",true);
        GetComponent<PlayerSoundMgr>().PlayDie();

        Invoke("ShowOverUI",1.5f);
    }

    //停止刷怪
    public void StopRushMonster()
    {
        //for(int i=0;i<m_MosnterRush.Count;i++)
        //{
        //    m_MosnterRush[i].SetActive(false);
        //}
    }

    //播放镜头
    public void PlayCamera()
    {
        // GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = false;
        // GameObject.Find("Main Camera").GetComponent<Animator>().enabled = true;
        m_GameOverUI.ShowUI("游戏胜利");
        //if (GameMgr.GetInstance().m_IsFirst == false)
        //{
        //    m_GaemFirstWinOrOverUI.SetActive(true);
        //}
        //else
        //{ 
        //    m_GameOverUI.ShowUI("游戏胜利");
        //}

        GameMgr.GetInstance().m_IsFirst = true;
    }  

    //弹出失败界面
    public void ShowOverUI()
    { 
        m_GameOverUI.ShowUI("游戏失败"); 

        //播放失败背景音乐
        m_BGM.clip = m_GameOverClip;
        m_BGM.Play();
        Time.timeScale = 0;

        GameMgr.GetInstance().m_IsFirst = true;
    } 
}
