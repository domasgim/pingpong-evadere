using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    public InventoryObject inventory;
    bool InventoryVisualsEnabled = false;
    public GameObject InventoryVisuals;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if(item)
        {
            inventory.AddItem(new Item(item.item), 1);
            Destroy(other.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[12];
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryVisualsEnabled = !InventoryVisualsEnabled;
        }

        if (InventoryVisualsEnabled)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            InventoryVisuals.SetActive(true);

        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            InventoryVisuals.SetActive(false);
        }
            

        if (Input.GetKeyDown(KeyCode.F12))
        { inventory.Save(); }
        if (Input.GetKeyDown(KeyCode.F11))
        { inventory.Load(); }
    }
}
