using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{

    HideMesh hm;
    PhysicsMovement CubePhysics;

    float lastCollisionTime;
    float allowedJumpDelay = 0.25f;
    bool ableToJump = true;

    private void Start()
    {
        hm = GetComponent<HideMesh>();
        CubePhysics = GetComponent<PhysicsMovement>();


        if (hm != null) { hm.MeshRenderIsActive(false); }

        ableToJump = true;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // елси куб "зарядил прыжок" и косаося поверхности не далее "allowedJumpDelay" - прыгаем, и убираем заряд прыжка
            if (ableToJump && (Time.time < lastCollisionTime + allowedJumpDelay))
            {
                CubePhysics.JumpUp();
                ableToJump = false;
            }

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            CubePhysics.JumpDown();
        }


        if (hm != null)
        {
            // включаем отрисовку парашута пока нажата кнопка W
            if (Input.GetKeyDown(KeyCode.W)) { hm.MeshRenderIsActive(true); }
            else if (Input.GetKeyUp(KeyCode.W)) { hm.MeshRenderIsActive(false); }
        }
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.A))
        {
            CubePhysics.ApplyHorisontalForceZax(-1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CubePhysics.ApplyHorisontalForceZax(1f);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            CubePhysics.SpacebarVerticalLift();
           
        }
        if (Input.GetKey(KeyCode.W))
        {

            CubePhysics.ParashuteDrag();
        }


        
        CubePhysics.ApplyHorisontalDrag();  //после рассчёта инпута тормозим куб по горизонтали
    }

    private void OnCollisionEnter(Collision collision)
    {
        lastCollisionTime = Time.time;

        ableToJump = true;
        //print("colision");
    }
    private void OnCollisionStay(Collision collision)
    {
        lastCollisionTime = Time.time;
    }
    
}
