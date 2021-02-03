using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
