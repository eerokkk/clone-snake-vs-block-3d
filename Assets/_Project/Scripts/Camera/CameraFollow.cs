using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Vector3 cameraPositionOffset;
    [SerializeField]
    private float cameraMovespeed;
    [SerializeField]
    private GameObject player;

    private Vector3 smoothPosition;
    private Vector3 cameraPosition;

    private void Awake()
    {
        cameraPositionOffset = transform.position;
    }

    private void LateUpdate()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        cameraPosition = player.transform.position + cameraPositionOffset;
        smoothPosition = Vector3.Lerp(transform.position, cameraPosition, cameraMovespeed * Time.deltaTime);
        transform.position = cameraPosition;
    }
}
