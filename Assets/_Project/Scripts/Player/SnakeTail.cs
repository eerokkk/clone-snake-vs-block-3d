using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class SnakeTail : MonoBehaviour
{
    [SerializeField]
    private Transform playerHead;
    [SerializeField] 
    private float tailDiameter;
    [SerializeField] 
    private List<Transform> snakeTails = new List<Transform>();
    [SerializeField]
    private List<Vector3> snakeTailsPositions = new List<Vector3>();

    private void Start()
    {
        snakeTailsPositions.Add(playerHead.position);
        AddTail();
        AddTail();
    }

    private void Update()
    {
        float distance = (playerHead.position - snakeTailsPositions[0]).magnitude;

        if (distance > tailDiameter)
        {
            snakeTailsPositions.Insert(0, playerHead.position);
            snakeTailsPositions.RemoveAt(snakeTailsPositions.Count - 1);
            distance -= tailDiameter;
        }

        for (int i = 0; i < snakeTails.Count; i++)
        {
            snakeTails[i].position = Vector3.Lerp(snakeTailsPositions[i + 1], snakeTailsPositions[i], distance / tailDiameter);
        }
    }

    public void AddTail()
    {
        var tail = Instantiate(playerHead, snakeTailsPositions[snakeTailsPositions.Count - 1], Quaternion.identity, transform);
        snakeTails.Add(tail);
        snakeTailsPositions.Add(tail.position);
    }
}
