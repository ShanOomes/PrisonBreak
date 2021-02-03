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
    public Item(string name, float weight)
    {
        this.name = name;
        this.weight = weight;
    }
}

public class AccesItem : Item
{
    private int id;

    //Propertie
    public int ID { get { return this.id; } set { this.id = value; } }

    //Standard constructor
    public AccesItem()
        : base()
    {
        this.id = 0;
    }

    //Custom constructor
    public AccesItem(int id, string name, float weight)
        : base(name, weight)
    {
        this.id = id;
    }
}

public class BonusItem : Item
{
    private int points;

    //Propertie
    public int Points { get { return this.points; } set { this.points = value; } }

    //Standard constructor
    public BonusItem()
        : base()
    {
        this.points = 0;
    }

    //Custom constructor
    public BonusItem(int points, string name, int weight)
        : base(name, weight)
    {
        this.points = points;
    }
}
