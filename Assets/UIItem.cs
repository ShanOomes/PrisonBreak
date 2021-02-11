﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Item item;
    private Text itemText;

    // Start is called before the first frame update
    private void Awake()
    {
        itemText = GetComponent<Text>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if(this.item != null)
        {
            itemText.color = Color.white;
            itemText.text = item.Name;
        }
        else
        {
            itemText.color = Color.clear;
        }
    }

    public void BtnClick()
    {
        print("Selected item: " + item.Name);
    }
}
