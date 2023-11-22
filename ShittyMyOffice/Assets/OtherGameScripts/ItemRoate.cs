using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRoate : MonoBehaviour
{
  
    void Update()
    {
        Time.timeScale = 1;
        transform.Rotate(Vector3.up * Time.deltaTime *80);
    }
}
