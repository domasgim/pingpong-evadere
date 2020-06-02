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
        inventory.Container.Items.Clear();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryVisualsEnabled = !InventoryVisualsEnabled;
        }

        if (InventoryVisualsEnabled)
        {
            InventoryVisuals.SetActive(true);
        }
        else
            InventoryVisuals.SetActive(false);

        if (Input.GetKeyDown(KeyCode.F12))
        { inventory.Save(); }
        if (Input.GetKeyDown(KeyCode.F11))
        { inventory.Load(); }
    }
}
