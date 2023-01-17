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

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player))
        {
            return;
        }
        if (damage == 0)
        {
            Destroy(gameObject);
        }
        player.TryGetComponent(out SnakeTail snakeTail);
        player.TryGetComponent(out Rigidbody playerRigidbody);

        playerRigidbody.AddForce(new Vector3(0f, 0f, -100f), ForceMode.VelocityChange);
        snakeTail.RemoveTail(1);
        player.SetHealthPoints(-1);
        
        
        
        damage -= 1;
        text.text = damage.ToString();
    }
}
