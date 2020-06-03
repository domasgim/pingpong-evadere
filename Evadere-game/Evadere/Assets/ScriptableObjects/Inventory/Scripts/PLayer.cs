using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PLayer : MonoBehaviour
{
    public InventoryObject inventory;
    bool InventoryVisualsEnabled = false;
    public GameObject InventoryVisuals;
    public GameObject playerObject;

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

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryVisualsEnabled = !InventoryVisualsEnabled;
        }

        if (InventoryVisualsEnabled)
        {
            InventoryVisuals.SetActive(true);
            // playerObject.GetComponent<FirstPersonController>().enabled = false;

            // Cursor.lockState = CursorLockMode.None;
            // Cursor.visible = true;

        }
        else
        {
            InventoryVisuals.SetActive(false);
            // playerObject.GetComponent<FirstPersonController>().enabled = true;

            // Cursor.lockState = CursorLockMode.Locked;
            // Cursor.visible = false;
        }
            

        if (Input.GetKeyDown(KeyCode.F12))
        { inventory.Save(); }
        if (Input.GetKeyDown(KeyCode.F11))
        { inventory.Load(); }
    }
}
