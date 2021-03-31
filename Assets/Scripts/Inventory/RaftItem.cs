using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftItem : Item
{
    private int partId;
    //Propertie
    public int PartID { get { return this.partId; } set { this.partId = value; } }
    //Standard constructor
    public RaftItem()
        : base()
    {
        this.partId = 0;
    }

    //Custom constructor
    public RaftItem(int partId,string name, float weight)
        : base(name, weight)
    {
        this.partId = partId;
    }
}
