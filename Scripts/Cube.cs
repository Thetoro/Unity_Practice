using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Main.onSpace += changePosition;
    }

    public void changePosition()
    {
        transform.position = new Vector3(5,2,0);   
    }

}
