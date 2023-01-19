using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private int foodCount;

    private void Awake()
    {
        var text = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        foodCount = int.Parse(text);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player))
        {
            return;
        }

        player.SetHealthPoints(foodCount);

        player.TryGetComponent(out SnakeTail snakeTail);
        snakeTail.AddTail(foodCount);

        Destroy(gameObject);
    }
}
