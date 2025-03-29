using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Wheel Colliders")]
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    [Header("Wheel Transforms (for visual rotation)")]
    public Transform frontLeftTransform;
    public Transform frontRightTransform;
    public Transform rearLeftTransform;
    public Transform rearRightTransform;

    [Header("Car Settings")]
    public float maxAcceleration = 1500f;   // แรงขับเคลื่อน
    public float maxBrakeForce = 3000f;     // แรงเบรก
    public float maxTurnAngle = 30f;        // มุมเลี้ยวสูงสุด

    private Rigidbody rb;
    private float moveInput;
    private float steerInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 1200f;  // ตั้งค่ามวลของรถ
    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical"); // คันเร่ง
        steerInput = Input.GetAxis("Horizontal"); // เลี้ยว

        UpdateWheelVisuals();
        TiltCarWhileTurning(); // เรียกใช้ฟังก์ชันเอียงรถ

    }

    void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteering();
        ApplyBrakes();
    }

    void ApplyEngineForce()
    {
        float force = moveInput * maxAcceleration;

        // ใช้แรงขับที่ล้อหลัง
        rearLeftWheel.motorTorque = force;
        rearRightWheel.motorTorque = force;
    }

    void ApplySteering()
    {
        
        float steerAngle = steerInput * maxTurnAngle;

        // หมุนล้อหน้าเพื่อเลี้ยว
        frontLeftWheel.steerAngle = steerAngle;
        frontRightWheel.steerAngle = steerAngle;
    }

    void ApplyBrakes()
    {
        if (Input.GetKey(KeyCode.Space))  // กด Space เพื่อเบรก
        {
            frontLeftWheel.brakeTorque = maxBrakeForce;
            frontRightWheel.brakeTorque = maxBrakeForce;
            rearLeftWheel.brakeTorque = maxBrakeForce;
            rearRightWheel.brakeTorque = maxBrakeForce;
        }
        else
        {
            frontLeftWheel.brakeTorque = 0;
            frontRightWheel.brakeTorque = 0;
            rearLeftWheel.brakeTorque = 0;
            rearRightWheel.brakeTorque = 0;
        }
    }

    void UpdateWheelVisuals()
    {
        UpdateWheelTransform(frontLeftWheel, frontLeftTransform);
        UpdateWheelTransform(frontRightWheel, frontRightTransform);
        UpdateWheelTransform(rearLeftWheel, rearLeftTransform);
        UpdateWheelTransform(rearRightWheel, rearRightTransform);
    }

    void UpdateWheelTransform(WheelCollider collider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
    void TiltCarWhileTurning()
    {
        float speedFactor = rb.velocity.magnitude / 50f; // คำนวณจากความเร็ว (ปรับได้)
        float tiltAmount = steerInput * -10f * speedFactor; // ยิ่งเร็ว ยิ่งเอียง
        Quaternion targetTilt = Quaternion.Euler(0, transform.eulerAngles.y, tiltAmount);
    
        transform.rotation = Quaternion.Lerp(transform.rotation, targetTilt, Time.deltaTime * 5f);
    }
    
}