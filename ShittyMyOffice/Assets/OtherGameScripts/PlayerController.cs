using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
//这个角色控制器 跳跃 用的是刚体+碰撞来实现的
public class PlayerController : MonoBehaviour
{ 
    public float speed = 10.0f;

    public float jumpForce;

    public bool IsLockMouse;

    private Animator m_Animator;   

    private Transform cam;

    float turnSmoothVelocity;

    private float horizontal;

    private float vertical;

    private float turnSmoothTime = 0.1f;

    private bool canjump = true;

    private Rigidbody rb;    

    private PlayerFms m_PlayerFsm;

    //是否被控制
    public bool m_IsController;

    void Start()
    {
        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        m_PlayerFsm = GetComponent<PlayerFms>();
        m_Animator = GetComponent<Animator>();

        if (IsLockMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        m_IsController = true;
    }  
   
    void Update()
    { 
        if(!m_IsController)
            return;
        
        Jump();  

        MoveDown();
    }    
    
    //跳跃
    public void Jump()
    { 
        
        if(Input.GetKeyDown(KeyCode.Space) && canjump)
        {    
            //为刚体添加一个向上的力
            rb.AddForce(Vector3.up * (jumpForce)); 
            m_Animator.SetBool("Jump",true);
            m_Animator.SetBool("Run", false);
            canjump = false; 
            GetComponent<PlayerSoundMgr>().PlayJumpSound();
        } 

       //当刚体速度小于-1的时候就证明下落了
       if(rb.velocity.y<=-0.5)
       { 
            //这个时候给它加一个向下的力量
            m_Animator.SetBool("JumpDown",true);
       }
    }  

     public void Jump1()
    {  
         
        
        //为刚体添加一个向上的力
        rb.AddForce(Vector3.up * (jumpForce)); 
        m_Animator.SetBool("Jump",true);
        m_Animator.SetBool("Run", false);
        canjump = false; 
        GetComponent<PlayerSoundMgr>().PlayJumpSound();
        

       //当刚体速度小于-1的时候就证明下落了
       if(rb.velocity.y<=-0.5)
       { 
            //这个时候给它加一个向下的力量
            m_Animator.SetBool("JumpDown",true);
       }
    }  

    //下移动
    public void MoveDown()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            m_PlayerFsm.ChangeState(E_State.MoveDown,gameObject);
            GetComponent<PlayerSoundMgr>().PlayeMoveDown();
        }
    }
    
     public void MoveDown1()
    {
       
        m_PlayerFsm.ChangeState(E_State.MoveDown,gameObject);
        GetComponent<PlayerSoundMgr>().PlayeMoveDown();
        
    }

    private void FixedUpdate() 
    { 
         
    }

    private void LateUpdate() 
    {
        transform.position = rb.transform.position; 
    }

    private void OnCollisionEnter(Collision collision) {
        
        if(collision.gameObject.CompareTag("Ground"))
        { 
            m_Animator.SetBool("Jump", false);
            m_Animator.SetBool("JumpDown",false);
              
        }
    } 

    //动画系统事件
    public void Event_JumpOver()
    {
        canjump = true;
        m_Animator.SetBool("Run",true);
    } 
}
