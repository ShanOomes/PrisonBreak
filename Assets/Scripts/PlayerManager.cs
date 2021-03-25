using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerManager : MonoBehaviour
{
    private Inventory inventory;
    public float initialMaxWeight=100;
    public UIInventory inventoryUI;
    public RectTransform HUD;
    private bool toggle;
    public TextMeshProUGUI currentWeight;
    public bool isTyping = false;
    private FirstPersonController fps;
    private Coroutine teleporting;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory(initialMaxWeight);
        fps = GetComponent<FirstPersonController>();
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
        if(isTyping == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                RaycastHit hit;

                if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 2))
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
                if (toggle)
                {
                    //slide hud up and down
                    HUD.DOAnchorPos(Vector2.zero, 0.25f);
                    GameManager.Instance.ToggleInterface();
                }
                else
                {
                    //slide hud up and down
                    HUD.DOAnchorPos(new Vector2(0, -381), 0.25f);
                    GameManager.Instance.ToggleInterface();
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
            currentWeight.text = inventory.GetCurrentWeight().ToString();
        }
        else
        {
            print("Problem!");
        }
    }

    private IEnumerator SetPos(Vector3 position)
    {
        fps.enabled = false;

        fps.transform.position = position;
        yield return new WaitForSeconds(0.1f);
        fps.enabled = true;
    }

    public void SetPosition(Vector3 position)
    {
        
        if (teleporting == null)
        {
            teleporting = StartCoroutine(SetPos(position));
            
        }
        
        
    }
}
