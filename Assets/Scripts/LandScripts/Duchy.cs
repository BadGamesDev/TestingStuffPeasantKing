using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Duchy : MonoBehaviour
{
    public string duchyName;
    
    public GameObject liege;
    public GameObject capital;
    public GameObject homeKingdom;
    
    public List<County> counties;
}