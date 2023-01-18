using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private const float repulsiveForce = -200f;
    [SerializeField]
    private int damage;
    [SerializeField]
    private TextMeshProUGUI text;

    private void Start()
    {
        damage = int.Parse(text.text);
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
        player.TryGetComponent(out Rigidbody playerRigidbody);

        //playerRigidbody.AddForce(new Vector3(0f, 0f, repulsiveForce), ForceMode.VelocityChange);
        snakeTail.RemoveTail();
        player.SetHealthPoints(-1);
        
        
        
        damage -= 1;
        text.text = damage.ToString();
    }
}
