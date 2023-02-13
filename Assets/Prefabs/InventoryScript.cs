using UnityEngine;
using System.Collections.Generic;

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

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
    }
}

[System.Serializable]
public class Item
{
    public string name;
    public int quantity;
    public int value;
}