using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PartyScript : MonoBehaviour
{
    public List<Pawn> party;
    public TMP_Text partySizeText;

    public int partySize;
    public int partySpeed;

    void Start()
    {
        partySize = 0;
        party = new List<Pawn>();
        
        for (int i = 0; i < 10; i++)
        {
            AddPawn();
        }
    }
    public void AddPawn()
    {
        GameManager gameManager = GameManager.Instance;
        gameManager.pawnID++;
        Pawn newSoldier = new Pawn();
        newSoldier.ID = gameManager.pawnID;
        newSoldier.name = "Soldier";
        newSoldier.experience = Random.Range(0, 81);
        newSoldier.talent = Random.Range(2, 7);
        party.Add(newSoldier);
        partySize++;
        partySizeText.text = partySize.ToString();
    }
}

[System.Serializable]
public class Pawn
{
    public int ID;
    public string name;
    public int experience;
    public int talent;
}
