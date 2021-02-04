using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public int doorIndex;

    private Rigidbody rb;
    void Start()
    {
        gameObject.tag = "Interactable";
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void Action(PlayerManager player)
    {
        if (player.AccessInventory(doorIndex))
        {
            rb.isKinematic = false;
        }
    }
}
