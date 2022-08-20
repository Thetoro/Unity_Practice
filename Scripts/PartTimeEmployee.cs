using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTimeEmployee : AbtractClass
{

    public int hoursWorked;
    public int hourlyRate;

    // Start is called before the first frame update
    void Start()
    {
        CalculateMonthlySalary();
    }

    public override void CalculateMonthlySalary()
    {
        Debug.Log(hoursWorked*hourlyRate);
    }
}
