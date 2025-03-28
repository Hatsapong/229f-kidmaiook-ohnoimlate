using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHandler : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    Transform gameModel;

    //Max values
    float maxSteerVelocity = 2f;
    float maxForwardVelocity = 30f;

    //Multipliers
    float accelerationMultiplier = 3f;
    float breaksMultiplier = 15f;
    float steeringMultiplier = 5f;

    //Input
    Vector3 input = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Rotate car model when "turning"
        gameModel.transform.rotation = Quaternion.Euler(0, rb.linearVelocity.x * 5, 0);
    }

    // reverseSpeed
    private float reverseSpeed = 2f;

    private void FixedUpdate()
    {
        //Apply Acceleration
        if (input.y > 0)
            Accelerate();
        else if (input.y < 0)
            Reverse(); // New function to handle reversing
        else
            rb.angularDamping = 0.2f;

        //Apply Brakes
        if (input.y < 0)
            Brake();

        Steer();
        
        
    }

    void Reverse()
    {
        rb.AddForce(-transform.forward * reverseSpeed, ForceMode.Acceleration);
    }

    void Accelerate()
    {
        rb.angularDamping = 0;

        //Stay within the speed limit
        if (rb.linearVelocity.z >= maxForwardVelocity)
            return;

        rb.AddForce(rb.transform.forward * accelerationMultiplier * input.y);
    }

    void Brake()
    {
        //Don't brake unless we are going forward
        if (rb.linearVelocity.z <= 0)
            return;

        rb.AddForce(rb.transform.forward * breaksMultiplier * input.y);
    }

        void Steer()
        {
            if (Mathf.Abs(input.x) > 0)
            {
                //Move the car sideways
                float speedBaseSteerLimit = rb.linearVelocity.z / 5.0f;
                speedBaseSteerLimit = Mathf.Clamp01(speedBaseSteerLimit);

                rb.AddForce(rb.transform.right * steeringMultiplier * input.x * speedBaseSteerLimit);

                //Normalize the X Velocity
                float normalizedX = rb.linearVelocity.x / maxSteerVelocity;

                //Ensure that we don't allow it to get bigger than 1 in magnitued. 
                normalizedX = Mathf.Clamp(normalizedX, -1.0f, 1.0f);

                //Make sure we stay within the turn speed limit
                rb.linearVelocity = new Vector3(normalizedX * maxSteerVelocity, 0, rb.linearVelocity.z);
            }
            else
            {
                //Auto center car
                rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, new Vector3(0, 0, rb.linearVelocity.z), Time.fixedDeltaTime * 3);
            }
        }
    public void SetInput(Vector3 inputVector)
    {
        inputVector.Normalize();

        input = inputVector;
    }
}

