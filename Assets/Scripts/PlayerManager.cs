using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Inventory inventory;
    public float initialMaxWeight=100;
    public UIInventory inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory(initialMaxWeight);
    }

    public bool AddItem(Item i)
    {
        if (inventory.CheckWeight(i))
        {
            inventoryUI.AddNewItem(i);
        }
        return inventory.AddItem(i);
    }

    public bool AccessInventory(int i)
    {
        return inventory.CanOpenDoor(i);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;

            if(Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 2))
            {
                IInteractable i = hit.collider.gameObject.GetComponent<IInteractable>();
                if (i != null)
                {
                    i.Action(this);
                }
            }
        }
    }

    public void DropItem(string name)
    {
        Item i = inventory.GetItemWithName(name);
        if(i != null)
        {
            inventoryUI.RemoveItem(i);
            //remove it from inventory
            inventory.RemoveItem(i);

            //sets item back into the world, respawns item
            GameManager.Instance.DropItem(name, transform.position + transform.forward);
        }
    }
}
