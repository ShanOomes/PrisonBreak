﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        //CreateKey();
        //TestInventoryFuncionality();
        TestPuzzleItem();
    }

    private void CreateKey()
    {
        Item i = new AccesItem(3, "Key of doom", 10f);
        DebugItem(i);

        Item b = new BonusItem(100, "Potato of the gods", 10);
        DebugItem(b);
    }

    private void TestPuzzleItem()
    {
        Item p = new PuzzleItem("Is blue blue?", "blue", "Color riddle", 5f);
        string answer = "blue";

        if(p is PuzzleItem)
        {
            //cast
            PuzzleItem i = (PuzzleItem)p;
            DebugTest(i);
            print(i.IsSolved());
            if (i.CheckAnswer(answer))
            {
                print("Solved riddle!");
                print(i.IsSolved());
            }
            else
            {
                print("riddle wasn't solved");
            }
        }

    }
    private void TestInventoryFuncionality()
    {
        // doorId - name - weight
        Item i = new AccesItem(1, "Key of doom", 50f);

        // points - name - weight
        Item b = new BonusItem(10, "Potato of the gods", 50f);
        Item c = new BonusItem(10, "Potato of the gods", 10f);
        DebugTest(i);
        DebugTest(b);
        DebugTest(c);

        inventory.DebugInventory();

        if (inventory.CanOpenDoor(1))
        {
            print("Door 1 can be opened.");
        }
        else
        {
            print("Door 1 can't be opened.");
        }

        if (inventory.HasItem(i))
        {
            print("Key of doom is in inventory");
        }
        else
        {
            print("Key is not in inventory");
        }

        if (inventory.RemoveItem(i))
        {
            print("Key was removed from inventory");
        }
        else
        {
            print("key was not removed");
        }

        if (inventory.CanOpenDoor(1))
        {
            print("Door 1 can be opened.");
        }
        else
        {
            print("Door 1 can't be opened.");
        }

        if (inventory.HasItem(i))
        {
            print("Key of doom is in inventory");
        }
        else
        {
            print("Key is not in inventory");
        }

    }

    //check if item was correctly add to inventory
    private void DebugTest(Item i)
    {
        if (inventory.AddItem(i))
        {
            print("Added: " + i.Name + " to the inventory");
        }
        else
        {
            print("Failed to add: " + i.Name + " to the inventory");
        }
    }

    //Debugs info of the item
    public void DebugItem(Item i)
    {
        string itemInfo = "The item: " + i.Name + " weighs " + i.Weight + "Kg";
        string extraInfo = "";
        if(i is AccesItem)
        {
            AccesItem ai = (AccesItem)i;
            extraInfo = " and opens door: " + ai.DoorID;
        }else if(i is BonusItem)
        {
            BonusItem bi = (BonusItem)i;
            extraInfo = " and give you: " + bi.Points;
        }

        print(itemInfo + extraInfo);
    }
}
