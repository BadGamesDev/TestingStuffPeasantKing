using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandHierarchy : MonoBehaviour
{
    public List<Kingdom> kingdoms;

    //THINGS TO DO MANUALLY:

    // 1-ASSIGN NAMES
    // 2-ASSIGNCAPITALS
    // 3-ASSIGN LIEGES
    // 4-ASSIGN HOME CITIES FOR VILLAGES (THIS MIGHT BE AUTOMATED LATER)

    private void Start()
    {
        GameObject[] kingdomObjects = GameObject.FindGameObjectsWithTag("Kingdom");

        kingdoms = new List<Kingdom>();

        foreach (GameObject kingdomObject in kingdomObjects)
        {
            Kingdom kingdom = kingdomObject.GetComponent<Kingdom>();
            
            GameObject[] duchyObjects = GetChildObjectsWithTag(kingdomObject, "Duchy");
            kingdom.duchies = new List<Duchy>();

            foreach (GameObject duchyObject in duchyObjects)
            {
                Duchy duchy = duchyObject.GetComponent<Duchy>();
                duchy.homeKingdom = kingdomObject;
                
                GameObject[] countyObjects = GetChildObjectsWithTag(duchyObject, "County");
                duchy.counties = new List<County>();

                foreach (GameObject countyObject in countyObjects)
                {
                    County county = countyObject.GetComponent<County>();
                    county.homeDuchy = duchyObject;
                    
                    GameObject[] cityObjects = GetChildObjectsWithTag(countyObject, "City");
                    county.cities = new List<GameObject>();

                    foreach (GameObject cityObject in cityObjects)
                    {
                        county.cities.Add(cityObject);
                    }

                    GameObject[] villageObjects = GetChildObjectsWithTag(countyObject, "Village");
                    county.villages = new List<GameObject>();

                    foreach (GameObject villageObject in villageObjects)
                    {
                        county.villages.Add(villageObject);
                    }
                    duchy.counties.Add(county);
                }
                kingdom.duchies.Add(duchy);
            }
            kingdoms.Add(kingdom);
        }
    }

    //Method to get all child objects of a game object with a certain tag
    private GameObject[] GetChildObjectsWithTag(GameObject parentObject, string tag)
    {
        List<GameObject> childObjects = new List<GameObject>();

        foreach (Transform child in parentObject.transform)
        {
            if (child.CompareTag(tag))
            {
                childObjects.Add(child.gameObject);
            }
        }
        return childObjects.ToArray();
    }
}
