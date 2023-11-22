using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//击退,击倒触发器
public class HitToGoBackTrigger : MonoBehaviour
{
     private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player"))
        { 
            other.gameObject.GetComponent<CharacterState>().m_CurHp-=10;
        }
     }
}
