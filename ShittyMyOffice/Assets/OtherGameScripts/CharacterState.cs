using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.AI;
public class CharacterState : MonoBehaviour
{
    public int m_CurHp;
    public int m_MaxHp; 

    //杀敌数量
    public int m_KillEnemyNums;

    private Animator m_Animator;
    private NavMeshAgent m_Agent;

    public TigerMove TigerMove1;
    public TigerMove TigerMove2;
       
    private void Start() {
        m_Animator = GetComponent<Animator>();

        if(tag == "Player")
        {
            GameObject.Find("GameViewPanel").GetComponent<GameViewPanel>().UpdateUi(this);
        }

        m_KillEnemyNums = 0;
    }


    private void Update()
    {
        GameObject.Find("GameViewPanel").GetComponent<GameViewPanel>().UpdateUi(this);
    }

    public void Damage(int _damge)
    {
        m_CurHp -= 1;
        

        if(tag == "Enemy")
        {
           // GetComponent<AiBase>().m_CurState = E_AIState.Hit;
        }
        else if(tag == "Player")
        {
          //  m_Animator.SetTrigger("Hit"); 
        
        }

        //Hp 为0
        if(m_CurHp<=0)
        {
            if(tag == "Player")
            {
                //让老虎向前
                TigerMove2.F();
                TigerMove1.F();

                Invoke("GameOver", 1.5f);
            }
            else if(tag == "Enmey")
            {
                m_Animator.SetBool("Die",true); 
                GameObject.Destroy(gameObject);
                GetComponent<AiBase>().m_CurState = E_AIState.Die;
            }

            m_CurHp = 0;
        }

        if(tag == "Player")
        {
            GameObject.Find("GameViewPanel").GetComponent<GameViewPanel>().UpdateUi(this);
        }
    }

    public void GameOver()
    {
        GetComponent<PlayerMovePath>().Over(); 
    }
}
