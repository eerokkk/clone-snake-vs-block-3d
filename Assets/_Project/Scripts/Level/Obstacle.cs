using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private const int MinObstacleDamage = 1;
    private const int MaxObstacleDamage = 100;
    
    
    [SerializeField]
    private int damage;
    [SerializeField]
    private TextMeshProUGUI text;

    private void Awake()
    {
        RandomObstacleDamage();
        RefreshUIText();
    }

    private void Update()
    {
        DestroyObstacle();
    }

    private void DestroyObstacle()
    {
        if (damage == 0)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player))
        {
            return;
        }
        if (damage == 0)
        {
            Destroy(gameObject);
            return;
        }
        player.TryGetComponent(out SnakeTail snakeTail);

        snakeTail.RemoveTail();
        player.SetHealthPoints(-1);
        
        
        
        damage -= 1;
        RefreshUIText();
    }

    public int GetObstacleDamage()
    {
        return damage;
    }

    private void RandomObstacleDamage()
    {
        damage = Random.Range(MinObstacleDamage, MaxObstacleDamage);
    }

    private void RefreshUIText()
    {
        text.text = damage.ToString();
    }
}
