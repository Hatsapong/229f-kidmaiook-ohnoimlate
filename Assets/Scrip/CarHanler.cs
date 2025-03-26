using System;
using UnityEngine;

public class CarHanler : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
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
        
    }

    void Accelerate()
    {
        rb.linearDamping = 0;
    }
    
}
