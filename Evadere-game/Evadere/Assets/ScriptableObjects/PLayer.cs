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
        var item = other.GetComponent<Item>();
        if(item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
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
    }
}
