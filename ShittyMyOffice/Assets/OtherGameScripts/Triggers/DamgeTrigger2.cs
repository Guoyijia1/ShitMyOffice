using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeTrigger2 : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        { 
            other.GetComponent<CharacterState>() .Damage(10); 
             other.GetComponent<Animator>().SetTrigger("Hit");
             other.GetComponent<PlayerSoundMgr>().PlayHit();
        }
    }
}
