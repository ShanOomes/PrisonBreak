using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private float currentWeight = 0;
    private List<AccesItem> items = new List<AccesItem>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print("Current weight: " + currentWeight);
    }

    public void AddItem(AccesItem item)
    {
        //add the item
        items.Add(item);
        //add the weight to total
        foreach (AccesItem value in items)
        {
            currentWeight += value.Weight;
        }
    }

    public void RemoveItem(AccesItem item)
    {
        //remove the item
        items.Remove(item);
        //remove the weight of total
        foreach (AccesItem value in items)
        {
            currentWeight -= value.Weight;
        }
    }
}
