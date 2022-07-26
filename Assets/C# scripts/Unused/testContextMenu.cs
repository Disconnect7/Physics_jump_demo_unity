using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testContextMenu : MonoBehaviour
{


    [ContextMenuItem("qwe123", "Print111222333")]
    public bool asd;

    void Print111222333() 
    {
        print(111222333);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
