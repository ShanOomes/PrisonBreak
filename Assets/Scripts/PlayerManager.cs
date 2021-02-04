using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Inventory inventory;
    public float initialMaxWeight=100;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory(initialMaxWeight);
    }

    public bool AddItem(Item i)
    {
        return inventory.AddItem(i);
    }

    public bool AccessInventory(int i)
    {
        return inventory.CanOpenDoor(i);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Interactable"))
        {
            IInteractable i = hit.gameObject.GetComponent<IInteractable>();
            i.Action(this);
        }
    }
}
