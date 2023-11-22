using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YinFu : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<CharacterState>().m_KillEnemyNums++;
            GameObject.Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 160);
    }
}
