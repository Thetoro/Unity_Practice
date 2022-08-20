using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lists : MonoBehaviour
{

    public List<GameObject> objects = new List<GameObject>();
    public List<GameObject> objectsCreated = new List<GameObject>();
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(objectsCreated.Count < 10 && count < 10)
            {
                int i = Random.Range(0,objects.Count);
                GameObject figure = Instantiate(objects[i], new Vector3(Random.Range(-10,10),Random.Range(-10,10),0), Quaternion.identity);
                objectsCreated.Add(figure);
                count++;
            }   
        }
        
        if(objectsCreated.Count == 10)
        {
            foreach(var figure in objectsCreated)
            {
                figure.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            objectsCreated.Clear();
        }
    }
}
