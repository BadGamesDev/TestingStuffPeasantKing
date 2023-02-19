using System.Collections.Generic;
using UnityEngine;


public class VillageScript : MonoBehaviour
{
    public InventoryScript inventory;
    
    public GameObject traderPrefab;
    public GameObject recruitPartyPrefab;

    public string county;
    public GameObject homeCounty;
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
        TimeManager.weekTickSend += OnWeekTick;
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

    private void OnWeekTick()
    {
        if (inventory.GetTotalValue() >= 200000)
        {
            SendTrader();
        }
    }
    private void OnMonthTick()
    {
        inventory.AddItem(new Item { name = "Wheat", quantity = wheatProduction, value = 10});
        inventory.AddItem(new Item { name = "Wood", quantity = woodProduction, value = 30});
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
        { //APPARENTLY THIS SHIT FIXES BUGS, IS THE LOCK STILL NEEDED? WHO KNOWS!
            List<Item> itemsToRemove = new List<Item>();

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
                            itemsToRemove.Add(new Item { name = item.name, quantity = quantity, value = item.value });
                        }
                    }
                    else
                    {
                        int quantity = Random.Range(item.quantity / 2, item.quantity + 1);
                        traderScript.inventory.AddItem(new Item { name = item.name, quantity = quantity, value = item.value });
                        itemsToRemove.Add(new Item { name = item.name, quantity = quantity, value = item.value });
                    }
                }
            }

            foreach (Item itemToRemove in itemsToRemove)
            {
                inventory.RemoveItem(itemToRemove);
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
    
    public void SendRecruits()
    {
        //FIND BETTER NAMES
        int recruitCount = Random.Range(population / 20, population / 10);
        population -= recruitCount;
        GameObject recruitParty = Instantiate(recruitPartyPrefab, transform.position, transform.rotation);
        RecruitScript recruitScript = recruitParty.GetComponent<RecruitScript>();
        PartyScript recruitPartyScript = recruitParty.GetComponent<PartyScript>();
        recruitScript.home = gameObject;
        recruitScript.liege = liege;
        recruitScript.destination = liege.transform.position;
        recruitPartyScript.AddPawn(recruitCount);
    }
}

