using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPropety : MonoBehaviour
{

    public bool toggle = true;
    private bool toggleLastState = true;

     


    public bool flag;
    public bool FlagProprty
    {
        get 
        { 
            return flag;
        }
        set 
        {
            flag = value;

            print("propety 'flag' was set");
            print(flag);
           
        }
    
    }


    private void Update()
    {
        if (toggle != toggleLastState)
        {
            toggleLastState = toggle;

            this.FlagProprty = toggle;
        }
    }
}
