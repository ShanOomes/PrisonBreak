using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Access : Pickup
{
    public int doorId;

    public override Item CreateItem()
    {
        return new AccesItem(doorId, itemName, weight);
    }
}
