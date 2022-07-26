using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCallOtherScript : MonoBehaviour
{
        
    [SerializeField] 
    GameObject[] goArray;
    MeshRenderer[] mrArray;

    
    private void Awake()
    {
        mrArray = new MeshRenderer[goArray.Length];


        

    }

    public void MeshRenderIsActive(bool state)
    {
        for (int i = 0; i < goArray.Length; i++)
        {
            mrArray[i] = goArray[i].GetComponent<MeshRenderer>();
            mrArray[i].enabled = state;
        }
    }




}
