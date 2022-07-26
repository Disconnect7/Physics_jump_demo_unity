using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrarshuteVector : MonoBehaviour
{
        
    [SerializeField] Transform PlayerCubeTransform;
    [SerializeField] [Range(0,1)] float t;
    [SerializeField] [Range(0,5)] float asd = 3f;
        

    private Rigidbody rd;
    private Vector3 _v1;
    private Quaternion _whereToLook;

    private void Awake()
    {
        rd = PlayerCubeTransform.GetComponent<Rigidbody>();
    }




     /* 
        направляем парашут против скорости куба
    
        если скорость у куба мальенькая < asd, то парашут поворавичается вверх
     
     */
    void Update()
    {
        _v1 = -1 * rd.velocity.normalized; 

        _whereToLook = Quaternion.LookRotation(_v1, new Vector3(1,0,0));

        float v_mag = rd.velocity.magnitude;

        if (v_mag > asd)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _whereToLook, t);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.up, new Vector3(1, 0, 0)), t);
        }


    }
}
