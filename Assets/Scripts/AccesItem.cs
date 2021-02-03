using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesItem : Item
{
    private int doorId;

    //Propertie
    public int DoorID { get { return this.doorId; } set { this.doorId = value; } }

    //Standard constructor
    public AccesItem()
        : base()
    {
        this.doorId = 0;
    }

    //Custom constructor
    public AccesItem(int doorId, string name, float weight)
        : base(name, weight)
    {
        this.doorId = doorId;
    }
}
