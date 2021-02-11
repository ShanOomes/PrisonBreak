using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private float currentWeight;
    private float maximumWeight;
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
        currentWeight = 0;
        maximumWeight = 100;
    }

    public Inventory(float maximumWeight) : this()
    {
        this.maximumWeight = maximumWeight;
    }

    public bool CheckWeight(Item item)
    {
        if(currentWeight + item.Weight <= maximumWeight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
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

    public Item GetItemWithName(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].Name == name)
            {
                return items[i];
            }
        }
        return null;
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
        Debug.Log("Inventory has " + Count() + " items");
        Debug.Log("Total weight " + GetCurrentWeight() + " Kg");

        foreach (Item item in items)
        {
            Debug.Log(item.Name + "---------" + item.Weight);
        }
    }
}
