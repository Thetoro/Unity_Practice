using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Item 
{
    public string name;
    public int itemID;
    public int buff;
}

public class LinQ : MonoBehaviour
{
    //public int[] grades = new int[] {50,55,68,70,69,80,90,99,100,10,18,17,26,30};
    
    public List<Item> items;

    void Start()
    {
        /*var grade = grades.Where(g => g > 69);
        foreach (var g in grade)
        {
            Debug.Log(g);
        }*/

        var foundID = items.Any(found => found.itemID == 3);
        Debug.Log("ID 3 is " + foundID);

        var buffs = items.Where(b => b.buff > 10);
        foreach (var b in buffs)
        {
            Debug.Log("Items with buff > 10: " + b.name);
        }

        var onlyBuffs = items.Average(b => b.buff);
        Debug.Log("Average buff: " + onlyBuffs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
