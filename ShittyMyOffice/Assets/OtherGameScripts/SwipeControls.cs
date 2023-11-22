using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//手势
public class SwipeControls : MonoBehaviour
{
    // drag speed factor
    public float dragSpeedFactor = 10f;
    // maximum force magnitude
    public float maxForceMagnitude = 100f;
    
    // Rigidbody component of the object
    private Rigidbody rb;
    // finger position on the screen when the swipe begins
    private Vector2 fingerStartPosition;
    // finger position on the screen while swiping
    private Vector2 fingerDiff;
    // normalized direction of the swipe
    private Vector2 swipeDirection;
    
    public Text  TestText;

    void Awake()
    {
        // get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        // detect finger touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        { 
            // record the initial finger position
            fingerStartPosition = Input.GetTouch(0).position;
            // reset swipe direction
            swipeDirection = Vector2.zero;
        }
        // detect finger swipe
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // calculate the swipe direction
            fingerDiff = Input.GetTouch(0).position - fingerStartPosition;
            swipeDirection = fingerDiff.normalized;
        }
        // detect finger release
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {    
            if(swipeDirection.y > 0)
            { 
               // TestText.text = "向上滑动";
                GetComponent<PlayerController>().Jump1();
            }
            else if(swipeDirection.y<0)
            { 
               // TestText.text = "向下滑动";
                GetComponent<PlayerController>().MoveDown1();
            }
            // // apply the swipe force
            // rb.AddForce(swipeDirection * fingerDiff.magnitude * dragSpeedFactor, ForceMode.Impulse);
        }
    }
}
