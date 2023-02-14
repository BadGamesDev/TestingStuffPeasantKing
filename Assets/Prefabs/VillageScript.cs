using UnityEngine;


public class VillageScript : MonoBehaviour
{
    public InventoryScript inventory;
    public GameObject traderPrefab;
    public GameObject homeCity;
    public GameObject lord;

    public int population;
    public int taxRate;

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
        consumeFood();
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
        payTaxes();
    }

    public void SendTrader()
    {
        GameObject tradeParty = Instantiate(traderPrefab, transform.position, transform.rotation);
        TraderScript traderScript = tradeParty.GetComponent<TraderScript>();
        traderScript.homeVillage = gameObject;
        traderScript.destination = homeCity.transform.position;

        foreach (Item item in inventory.items)
        {
            if (item.quantity > 0)
            {
                if (item.name == "Wheat")
                {
                    int quantity = Random.Range(0, item.quantity - population * 60);
                    traderScript.inventory.AddItem(new Item { name = item.name, quantity = quantity, value = item.value });
                    inventory.RemoveItem(new Item { name = item.name, quantity = quantity, value = item.value });
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
    
    public void consumeFood()
    {
        inventory.RemoveItem(new Item { name = "Wheat", quantity = population, value = 10 });
    }
    
    public void payTaxes()
    {
        if (inventory.money >= population * taxRate)
        {
            inventory.money -= population * taxRate;
            lord.GetComponent<InventoryScript>().money += population * taxRate;
        }
        else
        {
            inventory.money -= inventory.money;
            lord.GetComponent<InventoryScript>().money += inventory.money;
        }
    }
}
