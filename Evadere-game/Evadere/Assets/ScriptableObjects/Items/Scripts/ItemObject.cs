using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Equipment,
    Batteries,
    Default,
    Keys,
    Notes
}
public abstract class ItemObject : ScriptableObject
{
    public int ID;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}


[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public Item(ItemObject item )
    {
        Name = item.name;
        Id = item.ID;
    }
}
