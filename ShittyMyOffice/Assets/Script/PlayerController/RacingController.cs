using UnityEngine;
using System.Collections;

public class RacingController : MonoBehaviour
{
    public float normalSpeed = 20f;
    public float feverSpeed = 50f;

    public float lateralSpeed = 20f;
    public float turnSpeed = 3f;   // Turning speed of the car
    public float jumpForce = 5f;   
    public float accelerationSpeed = 5f;
    public float AccSpeed;


    public Vector3 jump;


    public float decelerationRate = 5f; // Rate at which the car slows down after a collision

    public float obstacleFlySpeed = 0.5f;

    private Rigidbody rb;
    private float currentSpeed;
    private bool isSpeedSlowed = false;

    private bool isGrounded = true;

    public bool FeverMode = false;

    private bool NormalMode = false;
    private bool GoToBeNormalMode = false;
    private bool GoToBeFeverMode = false;




    private void Start()
    {
        Physics.gravity = new Vector3(0, -50.0f, 0);
        rb = GetComponent<Rigidbody>();
        currentSpeed = normalSpeed;
        jump = new Vector3(0.0f, 5.0f, 0.0f);

        AccSpeed = 1f;

        StartCoroutine(ActivateFeverMode());
    }



    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {

            isGrounded = false;
        }

    }


    private void Update()
    {

        //Debug.Log(currentSpeed);

        // Player input for turning
        float horizontalInput = Input.GetAxis("Horizontal");
        //float turn = horizontalInput * turnSpeed;
        //transform.Rotate(0f, turn, 0f);


        if (FeverMode)
        {
            //currentSpeed = feverSpeed;
            AccSpeed = 3f;
        }
        else
        {
            currentSpeed = normalSpeed;//?
            AccSpeed = 1f;
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        transform.Translate(Vector3.forward * lateralSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * lateralSpeed * Time.deltaTime);

        if (currentSpeed < normalSpeed)
        {
            StartCoroutine(ReturnSpeed());
        }

        // z-axis
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime * AccSpeed);
    }


    IEnumerator ActivateFeverMode()
    {
        FeverMode = true;
        yield return new WaitForSeconds(2f);
        FeverMode = false;
    }

    IEnumerator ReturnSpeed()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);
        AddSpeed();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Rigidbody rbO = collision.gameObject.GetComponent<Rigidbody>();
            if (rbO != null)
            {
                rbO.AddForce(Vector3.up * obstacleFlySpeed, ForceMode.Impulse);
            }

            
            if (!FeverMode)
            {
                SlowDownSpeed();
            }
            
            //SlowDownSpeed();

        }

        if (collision.gameObject.CompareTag("ground"))
        {

            isGrounded = true;
        }
    }

    void SlowDownSpeed()
    {
        // Set the flag to true and adjust the speed
        //isSpeedSlowed = true;
        if (currentSpeed > 0)
        {
            currentSpeed -= decelerationRate;

        }
        
        //currentSpeed = Mathf.Max(currentSpeed, 1f); // Ensure speed doesn't go below 1
        
    }


    void AddSpeed()
    {

        if (currentSpeed < normalSpeed)
        {
            currentSpeed += accelerationSpeed * Time.deltaTime;
        }
        else
        {
            currentSpeed = normalSpeed;
        }
    }


    private void Jump()
    {

        if (isGrounded)
        {
            //GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);//能用
            //isGrounded = false;

            
        }
    }





}
