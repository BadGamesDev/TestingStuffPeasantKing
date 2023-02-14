using System.Collections.Generic;
using UnityEngine;

public class TraderScript : MonoBehaviour
{
    public InventoryScript inventory;
    public GameObject homeVillage;
    public Vector3 destination;

    public int goodsValue;

    private bool goingHome;

    private void Update()
    {
        if (goingHome)
        {
            transform.position = Vector3.MoveTowards(transform.position, homeVillage.transform.position, Time.deltaTime);
            if (transform.position == homeVillage.transform.position)
            {
                homeVillage.GetComponent<InventoryScript>().money += inventory.money;
                Destroy(gameObject);
            }
        }
        
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime);
            if (transform.position == destination)
            {
                inventory.money += inventory.GetTotalValue();
                inventory.items.Clear();
                goingHome = true;
            }
        }
    }
}