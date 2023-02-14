using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> villages = new List<GameObject>();

    void Start()
    {
        GameObject[] villageObjects = GameObject.FindGameObjectsWithTag("Village");
        foreach (GameObject village in villageObjects)
        {
            villages.Add(village);
        }
        villages[0].GetComponent<VillageScript>().lord = GameObject.Find("LordPembleton");
        villages[1].GetComponent<VillageScript>().lord = GameObject.Find("LordPembleton");
        villages[2].GetComponent<VillageScript>().lord = GameObject.Find("LordPembleton");
    }
}
