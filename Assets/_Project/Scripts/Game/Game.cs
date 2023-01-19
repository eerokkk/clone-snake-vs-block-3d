using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public enum GameState
    {
        Lose,
        Playing,
        Win
    }

    public GameState CurrentGameState { get; private set; }

    [SerializeField]
    private Player player;
    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private AudioSource gameAudioSource;
    [SerializeField]
    private AudioClip finishSound;

    private void Awake()
    {
        Instance = GetComponent<Game>();
        gameAudioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        CurrentGameState = GameState.Playing;
    }

    private void Update()
    {
        if (player.GetPlayerHealthPoints() == 0)
        {
            player.gameObject.SetActive(false);
            OnPlayerLose();
        }
    }

    public void OnPlayerWin()
    {
        CurrentGameState = GameState.Win;
        gameAudioSource.PlayOneShot(finishSound);
        player.gameObject.SetActive(false);
        winPanel.SetActive(true);
    }

    private void OnPlayerLose()
    {
        CurrentGameState = GameState.Lose;
        losePanel.SetActive(true);
    }
}
