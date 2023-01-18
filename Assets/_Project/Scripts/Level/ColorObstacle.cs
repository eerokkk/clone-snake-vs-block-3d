using UnityEngine;

public class ColorObstacle : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer obstacleMeshRenderer;
    [SerializeField]
    private Obstacle obstacle;

    private float gradient = 1f;

    private void Awake()
    {
        obstacleMeshRenderer = GetComponent<MeshRenderer>();
        obstacle = GetComponent<Obstacle>();
    }

    private void Update()
    {
        ChangeObstacleColorByGradient();
    }

    private void ChangeObstacleColorByGradient()
    {
        var obstacleDamage = obstacle.GetObstacleDamage();
        obstacleMeshRenderer.material.SetFloat("_Gradient", gradient);
        gradient = obstacleDamage / 100f;
    }
}
