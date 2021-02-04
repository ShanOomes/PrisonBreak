using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : Pickup
{
    public int points;

    public override Item CreateItem()
    {
        return new BonusItem(points, itemName, weight);
    }
}
