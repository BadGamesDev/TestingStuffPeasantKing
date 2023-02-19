using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class County : MonoBehaviour
{
    public string countyName;
    
    public GameObject liege;
    public GameObject capital;
    public GameObject homeDuchy;
    
    public List<GameObject> cities;
    public List<GameObject> villages;
}
