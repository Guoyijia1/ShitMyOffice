using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//石头
public class Rock : MonoBehaviour
{ 
    //特效
    public GameObject m_Effect;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enmey"))
        {
            other.gameObject.GetComponent<CharacterState>().Damage(1);
            GameObject.FindWithTag("Player").GetComponent<CharacterState>().m_KillEnemyNums++;
            GameObject.Find("GameViewPanel").GetComponent<GameViewPanel>().UpdateUi( GameObject.FindWithTag("Player").GetComponent<CharacterState>());
            GameObject.Destroy(gameObject);

            PlayerData.m_KillNums++;
            //特效
            GameObject.Instantiate(m_Effect,transform.position,Quaternion.identity);
            GameObject.FindWithTag("Player").GetComponent<PlayerSoundMgr>().PlayeRockHit();
        }
    }
}
