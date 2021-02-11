using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public int doorIndex;

    private Rigidbody rb;

    public bool open = false;
    void Start()
    {
        gameObject.tag = "Interactable";
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (open)
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
        }
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
