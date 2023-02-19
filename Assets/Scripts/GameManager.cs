using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<GameObject> villages = new List<GameObject>();
    public List<GameObject> cities = new List<GameObject>();

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
    }



 
}
