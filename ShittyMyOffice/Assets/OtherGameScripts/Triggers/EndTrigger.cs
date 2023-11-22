using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//终点触发器
public class EndTrigger : MonoBehaviour
{
    public AudioSource m_As;

    public AudioClip m_clip;
    private void OnTriggerEnter(Collider other) {
        //让角色停下来，播放胜利动画
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovePath>().Win();
            m_As.clip = m_clip;
            m_As.Play();
             
        }
    }


}
