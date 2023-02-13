using System.Collections.Generic;
using UnityEngine;

public class VillageScript : MonoBehaviour
{
    public InventoryScript inventory;
    public GameObject traderPrefab;
    public GameObject homeCity;

    public int wheatProduction;
    public int woodProduction;

    private void Start()
    {
        TimeScript.monthTickSend += OnMonthTick;
        inventory = GetComponent<InventoryScript>();
        wheatProduction = 10;
        woodProduction = 10;
    }

    private void OnMonthTick()
    {
        inventory.AddItem(new Item { name = "Wheat", quantity = wheatProduction, value = 5 });
        inventory.AddItem(new Item { name = "Wood", quantity = woodProduction, value = 10 });
        
        SendTrader();
    }

    public void SendTrader()
    {
        if (inventory.items.Count >= 2)
        { 
            GameObject tradeParty = Instantiate(traderPrefab, transform.position, transform.rotation);
            tradeParty.GetComponent<TraderScript>().destination = homeCity.transform.position;
        }
    }
}
