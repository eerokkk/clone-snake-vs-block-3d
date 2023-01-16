using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int playerHealthPoints;
    [SerializeField]
    private SnakeTail snakeTail;

    private void Start()
    {
        snakeTail = GetComponent<SnakeTail>();
    }

    public void SetHealthPoints(int foodCount)
    {
        playerHealthPoints += foodCount;
        snakeTail.AddTail(foodCount);
    }

    private void Awake()
    {
        var text = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        playerHealthPoints = int.Parse(text);
    }
}
