using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private float currentWeight = 0;
    private float maximumWeight = 100;
    private List<Item> items = new List<Item>();

    public bool AddItem(Item item)
    {
        if (currentWeight + item.Weight <= maximumWeight)
        {
            //add the item
            items.Add(item);
            //add the weight to total
            currentWeight += item.Weight;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveItem(Item item)
    {
        //remove the item
        bool succes = items.Remove(item);

        //remove the weight of total
        if (succes) { currentWeight -= item.Weight; }

        return succes;
    }

    public bool HasItem(Item item)
    {
        return items.Contains(item);
    }

    public bool CanOpenDoor(int id)
    {
        bool result = false;

        foreach (Item item in items)
        {
            if(item is AccesItem)
            {
                if(((AccesItem)item).OpensDoor(id))
                {
                    result = true;
                }
            }
        }
        return result;
    }

    public int Count()
    {
        return items.Count;
    }

    public float GetCurrentWeight()
    {
        return currentWeight;
    }

    public void DebugInventory()
    {
        print("Inventory has " + Count() + " items");
        print("Total weight " + GetCurrentWeight() + " Kg");

        foreach (Item item in items)
        {
            print(item.Name + "---------" + item.Weight);
        }
    }
}
