using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerDB : MonoBehaviour
{
    public Customer customer1;
    public Customer customer2;
    public Customer customer3;
    public Customer[] customers;

    // Start is called before the first frame update
    void Start()
    {
        customer1 = new Customer("Karym", "Reyes", 14, "Male", "Student");
        customer2 = new Customer("Kamila", "Reyes", 11, "Female", "Student");
        customer3 = new Customer("Juan", "Nieto", 23, "Male", "Student");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
