using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public int doorIndex;

    public bool open = false;

    void Start()
    {
        gameObject.tag = "Interactable";
        GameManager.Instance.RegisterDoors(this);
    }
    public void Open()
    {
        open = !open;
    }

    public void Action(PlayerManager player)
    {
        if (player.AccessInventory(doorIndex))
        {
            Open();
        }
    }
}
