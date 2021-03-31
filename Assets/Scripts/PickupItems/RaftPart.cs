using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftPart : Pickup
{
    public int partID;
    public override Item CreateItem()
    {
        return new RaftItem(partID, itemName, weight);
    }

    public void SetVariables(int id, string name, float value)
    {
        partID = id;
        itemName = name;
        weight = value;
    }
}
