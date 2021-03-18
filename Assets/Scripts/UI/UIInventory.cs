using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uIItems = new List<UIItem>();
    public static UIInventory Instance;
    public GameObject slotPrefab;
    public Transform slotPanel;

    private int numSlots = 8;

    public PlayerManager player;

    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < numSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab, slotPanel);
            UIItem uIItem = instance.GetComponentInChildren<UIItem>();
            uIItems.Add(uIItem);
        }

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateSlot(int slot, Item item)
    {
        uIItems[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.item == item), null);
    }
    public void DropItem(string name)
    {
        print(name);
        player.DropItem(name);
    }
}
