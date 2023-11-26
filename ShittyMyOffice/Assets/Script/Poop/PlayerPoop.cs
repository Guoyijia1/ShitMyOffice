using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPoop : MonoBehaviour
{
    [Header("Poop Collection")]
    [SerializeField] private TMP_Text poopNum;

    [Header("Fever Mode")]
    [SerializeField] private TMP_Text feverCheck;

    [Header("Opponent Detection")]
    [SerializeField] private float opponentDist = 5f;

    private int poopCollect = 0;
    private bool playerTag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Try enter Fever Mode
        StartCoroutine(CheckFever());

        // Try to throw poop
        StartCoroutine(CheckThrowPoop());
        
    }

    // Poop collection
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Poop"))
        {
            poopCollect++;
            poopNum.text = poopCollect.ToString();
            Destroy(other.gameObject);
        }
    }

    // Check if the player have enough poop to trigger Fever mode
    IEnumerator CheckFever()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if (poopCollect >= 5)
            {
                poopCollect -= 5;
                poopNum.text = poopCollect.ToString();
                StartCoroutine(Fever());
            } else
            {
                feverCheck.text = "You Don't Have Enough Poop!";
                yield return new WaitForSeconds(2f);
                feverCheck.text = string.Empty;
            }
            
        }
    }

    // Fever mode triggered
    IEnumerator Fever()
    {
        feverCheck.text = "FEVER MODE";
        yield return new WaitForSeconds(5f);
        feverCheck.text = string.Empty;
    }

    // Check if the player can throw the poop
    IEnumerator CheckThrowPoop()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, opponentDist);

            

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player") && collider.gameObject != gameObject)
                {
                    Debug.Log("player");
                    if (poopCollect >= 1)
                    {
                        StartCoroutine(ThrowPoop());  
                    }
                    else
                    {
                        feverCheck.text = "You Don't Have Enough Poop!";
                        yield return new WaitForSeconds(2f);
                        feverCheck.text = string.Empty;
                    }
                    playerTag = true;
                }
            }

            if (!playerTag)
            {
                feverCheck.text = "No Player Within Reach";
                yield return new WaitForSeconds(2f);
                feverCheck.text = string.Empty;
            }
        }

        playerTag = false;
    }

    // Throw Poop Now
    IEnumerator ThrowPoop()
    {
        poopCollect -= 1;
        poopNum.text = poopCollect.ToString();

        feverCheck.text = "THROW POOP!";
        yield return new WaitForSeconds(3f);
        feverCheck.text = string.Empty;
    }
}
