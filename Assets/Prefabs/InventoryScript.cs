using System.Collections.Generic;
using System;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public List<Item> items;
    public int money;

    public void AddItem(Item item)
    {
        foreach (Item i in items)
        {
            if (i.name == item.name)
            {
                i.quantity += item.quantity;
                return;
            }
        }
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        foreach (Item i in items)
        {
            if (i.name == item.name)
            {
                i.quantity -= item.quantity;
                if (i.quantity <= 0)
                {
                    items.Remove(i);
                }
                return;
            }
        }
    }

    public int GetTotalValue()
    {
        int totalValue = 0;
        foreach (Item item in items)
        {
            totalValue += item.quantity * item.value;
        }
        return totalValue;
    }
}

[System.Serializable]
public class Item
{
    public string name;
    public int quantity;
    public int value;
}