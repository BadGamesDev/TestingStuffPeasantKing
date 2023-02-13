using System.Collections.Generic;
using UnityEngine;

public class TraderScript : MonoBehaviour
{
    public Vector3 home;
    public Vector3 destination;
    public int money;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime);
    }
}