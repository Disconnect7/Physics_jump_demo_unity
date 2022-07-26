using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] float horisontal_speed = 15f;
    [SerializeField] float jumpPower = 50f;
    [SerializeField] float torque = 5f;
    [SerializeField] float SpacebarVerticalLiftValue = 1f;



    [SerializeField] float pow2dragZ = 0.2f;
    [SerializeField] [Range(0, 4)] float pow0dragZ = 1f;



    Rigidbody rd;
    

   


    private void Start()
    {
        rd = GetComponent<Rigidbody>();        
    }

    

    public void ApplyHorisontalForceZax(float direction)
    {
        rd.AddForce(new Vector3(0, 0, direction * horisontal_speed), ForceMode.Acceleration);
        rd.AddTorque(new Vector3(direction * torque, 0, 0));
    }
    public void ApplyHorisontalDrag()
    {
        float Vz = rd.velocity.z;
        float z_force = -1 * Mathf.Sign(Vz) * (pow2dragZ * (Vz * Vz) + pow0dragZ);

        rd.AddForce(new Vector3(0, 0, z_force), ForceMode.Acceleration);
        // rd.AddForce(new Vector3(0, 0, -1 * Mathf.Sign(Vz) * pow0dragZ), ForceMode.Acceleration);
    }
    public void ParashuteDrag()
    {
        float RotatoinAround_X_Axis = Mathf.Sign(rd.angularVelocity.x);
        float Xangular =  torque;

        float Vy = rd.velocity.y;
        float y_force = -1 * Mathf.Sign(Vy) * (2f * pow2dragZ * (Vy * Vy));

        rd.AddForce(new Vector3(0, y_force, 0), ForceMode.Acceleration);
        rd.AddTorque(new Vector3((-1) * 0.15f * torque * RotatoinAround_X_Axis, 0, 0));
        

        ApplyHorisontalDrag();
        ApplyHorisontalDrag();
    }

    public void JumpUp()
    {
        rd.AddForce(new Vector3(0, Mathf.Sqrt(jumpPower), 0), ForceMode.VelocityChange);
    }

    public void JumpDown()
    {
        rd.AddForce(new Vector3(0, -0.5f * Mathf.Sqrt(jumpPower), 0), ForceMode.VelocityChange);
    }

    public void SpacebarVerticalLift()
    {
        rd.AddForce(new Vector3(0, SpacebarVerticalLiftValue, 0), ForceMode.Acceleration);
    }
}
