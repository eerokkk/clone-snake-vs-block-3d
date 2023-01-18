using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int playerHealthPoints;
    [SerializeField]
    private SnakeTail snakeTail;
    [SerializeField]
    private TextMeshProUGUI playerHealthPointsCount;

    private void Start()
    {
        snakeTail = GetComponent<SnakeTail>();
    }

    public void SetHealthPoints(int count)
    {
        playerHealthPoints += count;
        playerHealthPointsCount.text = playerHealthPoints.ToString();
    }

    public void AddTails(int playerHealthPoint)
    {
        snakeTail.AddTail(playerHealthPoint);
    }

    private void Awake()
    {
        playerHealthPoints = int.Parse(playerHealthPointsCount.text);
    }

    public int GetPlayerHealthPoints()
    {
        return playerHealthPoints;
    }
}
