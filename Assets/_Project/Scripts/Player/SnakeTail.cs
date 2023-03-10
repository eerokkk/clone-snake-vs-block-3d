using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class SnakeTail : MonoBehaviour
{
    [SerializeField]
    private Transform playerHead;
    [SerializeField]
    private Transform snakeTail;
    [SerializeField] 
    private float tailDiameter;
    [SerializeField] 
    private List<Transform> snakeTails = new List<Transform>();
    [SerializeField]
    private List<Vector3> snakeTailsPositions = new List<Vector3>();

    private Player player;

    private void Start()
    {
        //snakeTails.Add(playerHead.transform);
        snakeTailsPositions.Add(playerHead.position);
        player = GetComponent<Player>();
    }

    private void Update()
    {
        float distance = (playerHead.position - snakeTailsPositions[0]).magnitude;

        if (distance > tailDiameter)
        {
            Vector3 direction = (playerHead.position - snakeTailsPositions[0]).normalized;

            snakeTailsPositions.Insert(0, snakeTailsPositions[0] + direction * tailDiameter);
            snakeTailsPositions.RemoveAt(snakeTailsPositions.Count - 1);
            distance -= tailDiameter;
        }

        for (int i = 0; i <= snakeTails.Count - 1; i++)
        {
            snakeTails[i].position = Vector3.Lerp(snakeTailsPositions[i + 1], snakeTailsPositions[i], distance / tailDiameter);
        }
    }

    public void AddTail(int tailCount)
    {
        for (int i = 0; i < tailCount; i++)
        {
            Transform tail = Instantiate(snakeTail, snakeTailsPositions[snakeTailsPositions.Count - 1], Quaternion.identity, transform);
            snakeTails.Add(tail);
            snakeTailsPositions.Add(tail.position);
        }
    }

    public void RemoveTail()
    {
        if (snakeTails.Count != 0)
        {
            var lastIndex = snakeTails.Count - 1;
            Destroy(snakeTails[lastIndex].gameObject);
            snakeTails.RemoveAt(lastIndex);
            snakeTailsPositions.RemoveAt(lastIndex);
        }
        else
            player.gameObject.SetActive(false);

    }
}

