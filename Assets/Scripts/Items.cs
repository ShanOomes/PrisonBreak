using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Item
{
    private string name;
    private int weight;

    //Properties
    public string Name { get { return this.name; } set { this.name  = value; } }
    public int Weight { get { return this.weight; } set { this.weight = value; } }

    //Standard constructor
    public Item()
    {
        name = "Default";
        weight = 0;
    }

    //Custom constructor
    public Item(string name, int weight)
    {
        this.name = name;
        this.weight = weight;
    }
}

class AccesItem : Item
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
    public AccesItem(int id, string name, int weight)
        : base(name, weight)
    {
        this.id = id;
    }
}

class BonusItem : Item
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

public class Items : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AccesItem doorKey = new AccesItem(3, "VaultKey", 10);
        print(doorKey.ID);
        print(doorKey.Name);
        print(doorKey.Weight);

        //AccesItem key = new AccesItem();
        //print(key.ID);
        //print(key.Name);
        //print(key.Weight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
