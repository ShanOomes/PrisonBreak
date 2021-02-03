using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateKey();
    }

    private void CreateKey()
    {
        Item i = new AccesItem(3, "Key of doom", 10f);
        DebugItem(i);
        //AccesItem ai = (AccesItem)i;

        //print("key ID: " + ai.DoorID);
        //print("key Name: " + ai.Name);
        //print("key Weight: " + ai.Weight);

        Item b = new BonusItem(100, "Potato of the gods", 10);
        DebugItem(b);
        //BonusItem bi = (BonusItem)b;

        //print("Item Points: " + bi.Points);
        //print("Item Name: " + bi.Name);
        //print("Item Weight: " + bi.Weight);
    }

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
