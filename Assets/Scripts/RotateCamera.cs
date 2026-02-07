using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCamera : MonoBehaviour
{
    float radius;
    float height;

    float angle;

    public float sensibility;

    [SerializeField]
    Camera camera_;
    [SerializeField]
    Transform center;

    void Start()
    {
        height = camera_.transform.position.y;
        radius = Mathf.Pow(camera_.transform.position.x, 2) + Mathf.Pow(camera_.transform.position.z, 2);
        radius = Mathf.Sqrt(radius);

        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnMouseDelta(InputValue _input)
    {
        angle += _input.Get<Vector2>().x / sensibility;
    }

    void Update()
    {
        camera_.transform.position = new Vector3(Mathf.Sin(angle) * radius, height, Mathf.Cos(angle) * radius);
        camera_.transform.LookAt(center, Vector3.up);
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

}
