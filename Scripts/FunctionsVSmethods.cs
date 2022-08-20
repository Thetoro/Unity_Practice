using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionsVSmethods : MonoBehaviour
{

    public Vector3[] pos;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            pos[i] = new Vector3(Random.Range(0,5),Random.Range(0,5),Random.Range(0,5));
        }
        Vector3 newPos = vectorSet(pos);
        transform.position = newPos;

    }

    private void Update()
    {
        
    }

    private Vector3 vectorSet(Vector3[] vecPos)
    {
        int index = indexGenerator();
        Vector3 newPos = vecPos[index];
        return newPos;
    }

    private int indexGenerator()
    {
        int index = Random.Range(0,5);
        return index;
    }




}
