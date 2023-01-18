using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerRigidbody;
    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private float forwardSpeed;

    private Vector3 touchLastPos;
    private float sidewaysSpeed;
    

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        playerRigidbody.velocity = new Vector3(sidewaysSpeed * 5, 0.0f, forwardSpeed);

        sidewaysSpeed = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchLastPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = Camera.main.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
            sidewaysSpeed += delta.x * sensitivity;
            touchLastPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
