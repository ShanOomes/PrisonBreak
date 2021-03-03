using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private Inventory inventory;
    public float initialMaxWeight=100;
    public UIInventory inventoryUI;
    public RectTransform HUD;
    private bool toggle;
    public Text currentWeight;

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
        currentWeight.text = inventory.GetCurrentWeight().ToString();
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

        if (Input.GetKeyDown(KeyCode.I))
        {
            toggle = !toggle;
            FirstPersonController fps = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
            if (toggle)
            {
                //slide hud up and down
                HUD.DOAnchorPos(Vector2.zero, 0.25f);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                fps.enabled = false;
            }
            else
            {
                //slide hud up and down
                HUD.DOAnchorPos(new Vector2(0, -381), 0.25f);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                fps.enabled = true;
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
            currentWeight.text = inventory.GetCurrentWeight().ToString();
        }
    }
}
