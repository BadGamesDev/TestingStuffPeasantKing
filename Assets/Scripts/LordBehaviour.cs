using UnityEngine;

public class LordBehaviour : MonoBehaviour
{
    public LordScript lordScript;
    public PartyScript partyScript;
    public GameObject seat;
    public float patrolRadius = 10f;
    public float moveSpeed = 2f;
    private Vector3 target;

    public delegate void OnVassalCall();
    public static event OnVassalCall vassalCallSend;
    public delegate void OnRecruitCall();
    public static event OnRecruitCall recruitCallSend;

    public string mode;

    void Start()
    {
        seat = lordScript.cities[0];
        target = GetRandomPosition();
        mode = "Call";
    }

    void Update()
    {
        if (mode == "Call")
        { 
            CallToArms(); 
        }
        Patrol(); 
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitCircle * patrolRadius;
        randomDirection += seat.transform.position;
        randomDirection.z = 0f;
        return randomDirection;
    }
    
    void Wait()
    {

    }

    void Patrol()
    {
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = GetRandomPosition();
        }

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    public void CallToArms()
    {
        if (lordScript.liege == null)
        {
            return;
        }
        if (mode == "Call")
        {
            CallRecruits();
        }
        else
        {
            TravelToLeader();
        }
    }

    public void CallVassals()
    {
        
    }
    
    public void CallRecruits()
    {
        foreach (GameObject village in lordScript.villages)
        {
            village.GetComponent<VillageScript>().SendRecruits();
        }
        mode = "stop";
    }

    private void TravelToLeader()
    {
        transform.position = Vector3.MoveTowards(transform.position, lordScript.liege.transform.position, moveSpeed * Time.deltaTime);
    }
}