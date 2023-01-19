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
    [SerializeField]
    private AudioSource playerAudioSource;
    [SerializeField]
    private AudioClip foodPickupSound;
    [SerializeField]
    private AudioClip collisionWithObstacleSound;
    [SerializeField]
    private AudioClip finishSound;

    private void Start()
    {
        snakeTail = GetComponent<SnakeTail>();
        playerAudioSource = GetComponent<AudioSource>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Food food))
        {
            return;
        }

        playerAudioSource.PlayOneShot(foodPickupSound);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Obstacle obstacle))
        {
            return;
        }

        playerAudioSource.PlayOneShot(collisionWithObstacleSound, 0.6f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Finish finish))
        {
            return;
        }

        playerAudioSource.PlayOneShot(finishSound);
    }
}
