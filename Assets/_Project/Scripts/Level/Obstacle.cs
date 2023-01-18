using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private TextMeshProUGUI text;

    private void Start()
    {
        damage = int.Parse(text.text);
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
        text.text = damage.ToString();
    }
}
