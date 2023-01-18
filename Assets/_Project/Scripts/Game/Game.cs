using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    [SerializeField]
    private Player player;

    private void Awake()
    {
        Instance = GetComponent<Game>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (player.GetPlayerHealthPoints() == 0)
        {
            print("Game Over!");
        }
    }
}
