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

    private void Start()
    {
        snakeTailsPositions.Add(playerHead.position);
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

        for (int i = 0; i < snakeTails.Count; i++)
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

    public void RemoveTail(int tailCount)
    {
        TryGetComponent(out Player player);

        print(snakeTails.Count);
        print(snakeTailsPositions.Count);

        var difference = player.GetPlayerHealthPoints() - tailCount;
        print(player.GetPlayerHealthPoints());
        print(difference);
        switch (difference)
        {
            case > 0:
                for (int i = player.GetPlayerHealthPoints(); i >= difference; i--)
                {
                    //print(snakeTails[i - 1]);
                    Destroy(snakeTails[i - 2].gameObject);
                    snakeTails.RemoveAt(i - 2);
                    snakeTailsPositions.RemoveAt(i);
                }
                break;
            case 0:
                for (int i = player.GetPlayerHealthPoints(); i > difference; i--)
                {
                    Destroy(snakeTails[i].gameObject);
                    snakeTails.RemoveAt(i);
                    snakeTailsPositions.RemoveAt(i);
                }
                print("Player is dead!");
                break;
            case < 0:
                for (int i = player.GetPlayerHealthPoints(); i > 0; i--)
                {
                    Destroy(snakeTails[i].gameObject);
                    snakeTails.RemoveAt(i);
                    snakeTailsPositions.RemoveAt(i);
                }
                print("Player is dead!");
                break;
        }
    }
}
