using UnityEngine;

public class RecruitScript : MonoBehaviour
{    
    public GameObject home;
    public GameObject liege;

    public PartyScript party;
    public Vector3 destination;

    private void Start()
    {
        party = gameObject.GetComponent<PartyScript>();
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime);
        if (transform.position == destination)
        {
            liege.GetComponent<PartyScript>().AddPawn(party.partySize);
            Destroy(gameObject);
        }
    }
}
