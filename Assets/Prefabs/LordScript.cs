using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LordScript : MonoBehaviour
{
    public InventoryScript inventory;

    public TMP_Text nameText;

    public List<GameObject> villages = new List<GameObject>();
    public List<GameObject> cities = new List<GameObject>();

    public string lordName;
    public string rank;
    public string allegiance;
    public GameObject liege;

    public int taxRate;
    public int debt;

    private void Start()
    {
        nameText.text = lordName;
        inventory.money += 150000;
        taxRate = 40000;
        TimeManager.yearTickSend += OnYearTick;
    }

    private void OnYearTick()
    {
        PayTaxes();
    }

    public void PayTaxes()
    {
        int taxOwed = taxRate * cities.Count * 10 + taxRate * villages.Count + debt;
        
        if (liege != null)
        {
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
}
