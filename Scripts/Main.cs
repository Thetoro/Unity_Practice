using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public delegate void spaceAction();
    public static event spaceAction onSpace;

    public void onSpaceDown()
    {
        if(onSpace != null)
            onSpace();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            onSpaceDown();
        }    
    }
}
