using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbtractClass : MonoBehaviour
{
    public string companyName;
    public string employeeName;
    
    public abstract void CalculateMonthlySalary();
}
