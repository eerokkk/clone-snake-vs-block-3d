using UnityEngine;

public class LevelMove : MonoBehaviour
{
    [SerializeField]
    private Vector3 levelPosition;
    [SerializeField]
    private float levelMovespeed;

    private void Awake()
    {
        levelPosition = this.transform.position;
    }

    private void Update()
    {
        LevelMovement();
    }

    private void LevelMovement()
    {
        levelPosition = new Vector3(0f, 0f, transform.position.z - levelMovespeed);
        transform.position = levelPosition;
    }
}
