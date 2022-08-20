using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullTimeEmployee : AbtractClass
{
    public float salary;
    
    // Start is called before the first frame update
    void Start()
    {
        CalculateMonthlySalary();
    }

    public override void CalculateMonthlySalary()
    {
        Debug.Log(salary);
    }
    
}
