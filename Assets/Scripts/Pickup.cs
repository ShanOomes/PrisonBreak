using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IInteractable
{
    public string itemName;
    public float weight;

    void Start()
    {
        gameObject.tag = "Interactable";
    }

    public void Action(PlayerManager player)
    {
        if (player.AddItem(CreateItem()))
        {
            Destroy(gameObject);
        }
    }

    public abstract Item CreateItem();
}
