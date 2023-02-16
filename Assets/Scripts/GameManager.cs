using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<GameObject> villages = new List<GameObject>();
    public List<GameObject> cities = new List<GameObject>();

    public GameObject lord0;
    public GameObject lord1;
    public GameObject lord2;
    public GameObject lord3;
    public GameObject lord4;
    public GameObject lord5;
    public GameObject lord6;
    public GameObject lord7;

    public LordScript lord0Script;
    public LordScript lord1Script;
    public LordScript lord2Script;
    public LordScript lord3Script;
    public LordScript lord4Script;
    public LordScript lord5Script;
    public LordScript lord6Script;
    public LordScript lord7Script;

    public int pawnID;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Duplicate GameManager detected, destroying the new instance.");
            Destroy(gameObject);
        }

        pawnID = 0;

        GameObject[] villageObjects = GameObject.FindGameObjectsWithTag("Village");
        GameObject[] cityObjects = GameObject.FindGameObjectsWithTag("City");

        lord0 = GameObject.Find("Lord0");
        lord1 = GameObject.Find("Lord1");
        lord2 = GameObject.Find("Lord2");
        lord3 = GameObject.Find("Lord3");
        lord4 = GameObject.Find("Lord4");
        lord5 = GameObject.Find("Lord5");
        lord6 = GameObject.Find("Lord6");
        lord7 = GameObject.Find("Lord7");

        lord0Script = lord0.GetComponent<LordScript>();
        lord1Script = lord1.GetComponent<LordScript>();
        lord2Script = lord2.GetComponent<LordScript>();
        lord3Script = lord3.GetComponent<LordScript>();
        lord4Script = lord4.GetComponent<LordScript>();
        lord5Script = lord5.GetComponent<LordScript>();
        lord6Script = lord6.GetComponent<LordScript>();
        lord7Script = lord7.GetComponent<LordScript>();

        lord0Script.lordName = "Doge";
        lord1Script.lordName = "Cheems";
        lord2Script.lordName = "Pinkguy";
        lord3Script.lordName = "Reddick";
        lord4Script.lordName = "Idubzz";
        lord5Script.lordName = "Prometheus";
        
        lord6Script.lordName = "Franku";
        lord7Script.lordName = "Chinchin";

        lord0Script.rank = "Count";
        lord1Script.rank = "Count";
        lord2Script.rank = "Count";
        lord3Script.rank = "Count";
        lord4Script.rank = "Count";
        lord5Script.rank = "Count";
        
        lord6Script.rank = "Duke";
        lord7Script.rank = "Duke";

        lord0Script.allegiance = "Blue";
        lord1Script.allegiance = "Blue";
        lord2Script.allegiance = "Blue";
        
        lord3Script.allegiance = "Red";
        lord4Script.allegiance = "Red";
        lord5Script.allegiance = "Red";
        
        lord6Script.allegiance = "Blue";
        lord7Script.allegiance = "Red";

        lord6Script.vassals.Add(lord0);
        lord0Script.liege = lord7;
        lord6Script.vassals.Add(lord1);
        lord1Script.liege = lord7;
        lord6Script.vassals.Add(lord2);
        lord2Script.liege = lord7;
        
        lord7Script.vassals.Add(lord3);
        lord3Script.liege = lord6;
        lord7Script.vassals.Add(lord4);
        lord4Script.liege = lord6;
        lord7Script.vassals.Add(lord5);
        lord5Script.liege = lord6;
        
        lord6Script.liege = null;
        lord7Script.liege = null;




        foreach (GameObject village in villageObjects)
        {
            villages.Add(village);
        }
        
        villages[0].GetComponent<VillageScript>().liege = lord0;
        lord0Script.villages.Add(villages[0]);
        villages[1].GetComponent<VillageScript>().liege = lord0;
        lord0Script.villages.Add(villages[1]);
        villages[2].GetComponent<VillageScript>().liege = lord0;
        lord0Script.villages.Add(villages[2]);
        villages[3].GetComponent<VillageScript>().liege = lord0;
        lord0Script.villages.Add(villages[3]);
        villages[4].GetComponent<VillageScript>().liege = lord1;
        lord1Script.villages.Add(villages[4]);
        villages[5].GetComponent<VillageScript>().liege = lord1;
        lord1Script.villages.Add(villages[5]);
        villages[6].GetComponent<VillageScript>().liege = lord1;
        lord1Script.villages.Add(villages[6]);
        villages[7].GetComponent<VillageScript>().liege = lord2;
        lord2Script.villages.Add(villages[7]);
        villages[8].GetComponent<VillageScript>().liege = lord2;
        lord2Script.villages.Add(villages[8]);
        villages[9].GetComponent<VillageScript>().liege = lord2;
        lord2Script.villages.Add(villages[9]);
        villages[10].GetComponent<VillageScript>().liege = lord3;
        lord3Script.villages.Add(villages[10]);
        villages[11].GetComponent<VillageScript>().liege = lord3;
        lord3Script.villages.Add(villages[11]);
        villages[12].GetComponent<VillageScript>().liege = lord3;
        lord3Script.villages.Add(villages[12]);
        villages[13].GetComponent<VillageScript>().liege = lord4;
        lord4Script.villages.Add(villages[13]);
        villages[14].GetComponent<VillageScript>().liege = lord4;
        lord4Script.villages.Add(villages[14]);
        villages[15].GetComponent<VillageScript>().liege = lord4;
        lord4Script.villages.Add(villages[15]);
        villages[16].GetComponent<VillageScript>().liege = lord5;
        lord5Script.villages.Add(villages[16]);
        villages[17].GetComponent<VillageScript>().liege = lord5;
        lord5Script.villages.Add(villages[17]);
        villages[18].GetComponent<VillageScript>().liege = lord5;
        lord5Script.villages.Add(villages[18]);
        villages[19].GetComponent<VillageScript>().liege = lord5;
        lord5Script.villages.Add(villages[19]);

        foreach (GameObject city in cityObjects)
        {
            cities.Add(city);
        }

        cities[0].GetComponent<CityScript>().liege = lord0;
        lord0Script.cities.Add(cities[0]);
        cities[1].GetComponent<CityScript>().liege = lord1;
        lord1Script.cities.Add(cities[1]);
        cities[2].GetComponent<CityScript>().liege = lord2;
        lord2Script.cities.Add(cities[2]);
        cities[3].GetComponent<CityScript>().liege = lord3;
        lord3Script.cities.Add(cities[3]);
        cities[4].GetComponent<CityScript>().liege = lord4;
        lord4Script.cities.Add(cities[4]);
        cities[5].GetComponent<CityScript>().liege = lord5;
        lord5Script.cities.Add(cities[5]);
        cities[6].GetComponent<CityScript>().liege = lord6;
        lord6Script.cities.Add(cities[6]);
        cities[7].GetComponent<CityScript>().liege = lord7;
        lord7Script.cities.Add(cities[7]);
    }
}
