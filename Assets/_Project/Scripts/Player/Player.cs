using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int playerHealthPoints;

    public void SetHealthPoints(int foodCount)
    {
        playerHealthPoints += foodCount;
    }

    private void Awake()
    {
        var text = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        playerHealthPoints = int.Parse(text);
    }
}
