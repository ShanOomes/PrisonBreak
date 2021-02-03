using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    private string name;
    private float weight;

    //Properties
    public string Name { get { return this.name; } set { this.name  = value; } }
    public float Weight { get { return this.weight; } set { this.weight = value; } }

    //Standard constructor
    public Item()
    {
        name = "Default";
        weight = 0;
    }

    //Custom constructor
    protected Item(string name, float weight)
    {
        this.name = name;
        this.weight = weight;
    }
}
