using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParashureFollowScript : MonoBehaviour
{
    [SerializeField] Transform cubeTransform;
    private Rigidbody rd_player;

    [SerializeField] [Range(0, 1)] float t;
    private float parashuteAngleSmothed = 0.1f;

   // [SerializeField] [Range(-360,360)]float ASD;

    private void Awake()
    {
        rd_player = cubeTransform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 v1 = rd_player.velocity.normalized;
        float alpha = 0;



        if (rd_player.velocity.magnitude >= 2f) // при околонулевой скорости парашут стоит на месте
        {

            if (v1.y > 0)
            {
                alpha = Mathf.Sin(v1.z);
            }
            else
            {
                alpha = Mathf.PI - Mathf.Sin(v1.z);
            }

        }

        else { alpha = +Mathf.PI; }


        print(alpha / Mathf.PI * 180 + 180);
        parashuteAngleSmothed = Mathf.Lerp(parashuteAngleSmothed, alpha / Mathf.PI * 180 + 180, t);

        //transform.rotation = Quaternion.Euler(ASD,0,0);
        transform.rotation = Quaternion.Euler(parashuteAngleSmothed, 0,0);

    }

    
}
