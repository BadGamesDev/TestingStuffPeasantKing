using UnityEngine;

public class LordBehaviour : MonoBehaviour
{
    public LordScript lordScript;
    public GameObject seat;
    public float patrolRadius = 10f;
    public float moveSpeed = 2f;
    private Vector3 target;

    void Start()
    {
        seat = lordScript.cities[0];
        target = GetRandomPosition();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = GetRandomPosition();
        }

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitCircle * patrolRadius;
        randomDirection += seat.transform.position;
        randomDirection.z = 0f;
        return randomDirection;
    }
}