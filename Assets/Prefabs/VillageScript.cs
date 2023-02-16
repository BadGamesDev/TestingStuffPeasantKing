using System.Collections.Generic;
using UnityEngine;


public class VillageScript : MonoBehaviour
{
    public InventoryScript inventory;
    
    public GameObject traderPrefab;
    public GameObject homeCity;
    public GameObject liege;
    

    public int population;
    public int taxRate;
    public int debt;

    public int wheatProduction;
    public int woodProduction;

    private void Start()
    {
        TimeManager.dayTickSend += OnDayTick;
        TimeManager.monthTickSend += OnMonthTick;
        TimeManager.yearTickSend += OnYearTick;

        population = 100;
        taxRate = 1000;

        wheatProduction = population * 35;
        woodProduction = population * 2;

        inventory.AddItem(new Item { name = "Wheat", quantity = population * 100, value = 10 });
    }

    private void OnDayTick()
    {
        //Make this monthly if there are performance problems
        ConsumeFood();
    }

    private void OnMonthTick()
    {
        inventory.AddItem(new Item { name = "Wheat", quantity = wheatProduction, value = 10});
        inventory.AddItem(new Item { name = "Wood", quantity = woodProduction, value = 30});

        if (inventory.GetTotalValue() >= 100000)
        {
            SendTrader();
        }
    }
    
    private void OnYearTick()
    {
        PayTaxes();
    }

    public void SendTrader()
    {
        GameObject tradeParty = Instantiate(traderPrefab, transform.position, transform.rotation);
        TraderScript traderScript = tradeParty.GetComponent<TraderScript>();
        traderScript.homeVillage = gameObject;
        traderScript.destination = homeCity.transform.position;

        lock (inventory)
        {
            List<Item> itemsCopy = new List<Item>(inventory.items);

            foreach (Item item in inventory.items)
            {
                if (item.quantity > 0)
                {
                    if (item.name == "Wheat")
                    {
                        int quantity = Mathf.Max(0, Random.Range(0, item.quantity - population * 60));
                        if (quantity > 0)
                        {
                            traderScript.inventory.AddItem(new Item { name = item.name, quantity = quantity, value = item.value });
                            inventory.RemoveItem(new Item { name = item.name, quantity = quantity, value = item.value });
                        }
                    }
                    else
                    {
                        int quantity = Random.Range(item.quantity / 2, item.quantity + 1);
                        traderScript.inventory.AddItem(new Item { name = item.name, quantity = quantity, value = item.value });
                        inventory.RemoveItem(new Item { name = item.name, quantity = quantity, value = item.value });
                    }
                }
            }
        }
    }
    
    public void ConsumeFood()
    {
        lock (inventory)
        {
            inventory.RemoveItem(new Item { name = "Wheat", quantity = population, value = 10 });
        }
    }
    
    public void PayTaxes()
    {
        int taxOwed = population * taxRate + debt;

        if (inventory.money >= taxOwed)
        {
            inventory.money -= taxOwed;
            liege.GetComponent<InventoryScript>().money += taxOwed;
            debt = 0;
        }
        else
        {
            debt += taxOwed - inventory.money;
            liege.GetComponent<InventoryScript>().money += inventory.money;
            inventory.money = 0;
        }
    }
}
