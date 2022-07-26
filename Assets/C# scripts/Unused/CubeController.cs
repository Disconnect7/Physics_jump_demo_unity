using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] float horisontal_speed = 15f;
    [SerializeField] float jumpPower = 50f;
    [SerializeField] float torque = 5f;
    [SerializeField] float SpacebarVerticalLift = 1f;



    [SerializeField] float pow2dragZ = 0.2f;
    [SerializeField] [Range(0, 4)] float pow0dragZ = 1f;



    Rigidbody rd;
    HideMesh hm;

    // Start is called before the first frame update


    private void Start()
    {
        rd = GetComponent<Rigidbody>();
        hm = GetComponent<HideMesh>();


        if (hm != null) { hm.MeshRenderIsActive(false); }
    }
       


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rd.AddForce(new Vector3(0, Mathf.Sqrt(jumpPower), 0), ForceMode.VelocityChange);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            rd.AddForce(new Vector3(0, -0.5f * Mathf.Sqrt(jumpPower), 0), ForceMode.VelocityChange);
        }


        if (hm != null)
        {
            // включаем отрисовку парашута пока нажата кнопка W
            if (Input.GetKeyDown(KeyCode.W)) { hm.MeshRenderIsActive(true); }
            else if (Input.GetKeyUp(KeyCode.W)) { hm.MeshRenderIsActive(false); }
        }

    }


    // Update is called once per frame
    private void FixedUpdate()
    {
       

        if (Input.GetKey(KeyCode.A))
        {
            ApplyHorisontalForceZax(-1f);            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyHorisontalForceZax(1f);            
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rd.AddForce(new Vector3(0, SpacebarVerticalLift, 0), ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.W))
        {
            ParashuteDrag();
        }



            ApplyHorisontalDrag(); //после рассчёта инпута тормозим куб по горизонтали
    }

    void ApplyHorisontalForceZax(float direction)
    {                
        rd.AddForce(new Vector3(0, 0, direction * horisontal_speed), ForceMode.Acceleration);
        rd.AddTorque(new Vector3(direction * torque, 0, 0));
    }
    void ApplyHorisontalDrag()
    {
        float Vz = rd.velocity.z;
        float z_force = -1 * Mathf.Sign(Vz) * (pow2dragZ * (Vz * Vz) + pow0dragZ);

        rd.AddForce(new Vector3(0, 0, z_force), ForceMode.Acceleration);
       // rd.AddForce(new Vector3(0, 0, -1 * Mathf.Sign(Vz) * pow0dragZ), ForceMode.Acceleration);
    }
    void ParashuteDrag()
    {        

        float Vy = rd.velocity.y;
        float y_force = -1 * Mathf.Sign(Vy) * (2f * pow2dragZ * (Vy * Vy) );

        rd.AddForce(new Vector3(0, y_force, 0), ForceMode.Acceleration);

        ApplyHorisontalDrag();
        ApplyHorisontalDrag();

    }
}
