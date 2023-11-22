using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody m_Rig;

     //特效
    public GameObject m_Effect;
    
    void Start()
    {
        m_Rig = GetComponent<Rigidbody>();
    }
  
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(m_Rig.velocity.normalized);
    } 

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
