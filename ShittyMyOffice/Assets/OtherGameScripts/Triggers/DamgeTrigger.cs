using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//扣血触发器
public class DamgeTrigger : MonoBehaviour
{
    public CharacterState m_State;

    public int m_Damge;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enmey"))
        {
            //被吃掉
            m_State.Damage(m_Damge);
            GameObject.Destroy(other.gameObject);
        }
    }
}
