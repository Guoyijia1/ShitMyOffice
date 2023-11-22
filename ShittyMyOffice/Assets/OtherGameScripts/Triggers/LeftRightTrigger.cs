using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightTrigger : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovePath>().m_IsLeftRightMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovePath>().m_IsLeftRightMove = true;
        }
    }
}
