using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class UIItem : MonoBehaviour
{
    public Item item;
    private Text itemText;
    public UIInventory manager;
    public Image obj;
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
            obj.enabled = true;
        }
        else
        {
            itemText.color = Color.clear;
            obj.enabled = false;
        }
    }

    public void DropItem()
    {
        if(item != null)
        {
            manager.DropItem(item.Name);
        }
        else
        {
            Debug.LogError("DropItem is null");
        }
    }
}
