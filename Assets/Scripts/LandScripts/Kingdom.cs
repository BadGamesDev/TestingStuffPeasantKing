using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Kingdom : MonoBehaviour
{
    public string kingdomName;
    
    public GameObject liege;
    public GameObject capital;
    
    public List<Duchy> duchies;
}
