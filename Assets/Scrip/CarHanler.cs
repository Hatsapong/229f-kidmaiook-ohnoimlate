using System;
using Unity.VisualScripting;
using UnityEngine;

public class CarHanler : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    
    //Multipliers
    private float accelerationMultipliers = 3;
    float breaksMultiplier = 15;
    float steeringMultipliers = 5;
    
    //Input
    Vector2 input = Vector2.zero;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Apply Acceleration
        if (input.y > 0)
            Accelerate();
        else 
            rb.drag = 0.2f;
        
        //Apply Brakes
        if (input.y < 0)
            Brake();
        
        Steer();
    }

    void Accelerate()
    {
        rb.drag = 0;
        
        rb.AddForce(rb.transform.forward * accelerationMultipliers * input.y);
    }

    void Brake()
    {
        //Dont brake unless we are going forward
        if (rb.velocity.z <= 0)
            return;
        
        rb.AddForce(rb.transform.forward * breaksMultiplier * input.y);
    }

    void Steer()
    {
        if (Mathf.Abs(input.x) > 0)
        {
            rb.AddForce(rb.transform.right * steeringMultipliers * input.x);
        }
    }

    public void SetInput(Vector2 inputVector)
    {
        inputVector.Normalize();
        
        input = inputVector;
    }
    
}
