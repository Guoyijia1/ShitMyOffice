using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeTrigger1 : MonoBehaviour
{  
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            if( other.GetComponent<PlayerFms>().m_CurState == E_State.MoveDown)
                    return;
             other.GetComponent<CharacterState>().Damage(10); 
             other.GetComponent<Animator>().SetTrigger("Hit");
             other.GetComponent<PlayerSoundMgr>().PlayHit();
        }
    }
}
