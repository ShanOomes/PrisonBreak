using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Dictionary<string, Pickup> worldItems = new Dictionary<string, Pickup>();//All the items in the world
    List<Door> doors = new List<Door>();
    private bool toggle;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void RegisterPickupItem(Pickup i)
    {
        if (!worldItems.ContainsKey(i.itemName))
        {
            worldItems.Add(i.itemName, i);
        }
        else
        {
            Debug.LogError("There is already an object with the name: " + i.itemName + ". The cannot be two items with the same name.");
        }
    }

    public void RegisterDoors(Door i)
    {
        doors.Add(i);
    }

    public void CallLockdown()
    {
        print("Lockdown activated!!");
        foreach (Door door in doors)
        {
            SlidingDoor i = (SlidingDoor)door;
            i.ResetDoor();
        }
    }
    public void DropItem(string name, Vector3 position)
    {
        worldItems[name].Respawn(position);
    }

    public void ToggleInterface()
    {
        toggle = !toggle;
        FirstPersonController fps = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        if (toggle)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            fps.enabled = false;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            fps.enabled = true;
        }
    }
}
