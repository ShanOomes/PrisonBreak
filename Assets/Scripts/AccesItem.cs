using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
