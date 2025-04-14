using UnityEngine;

public class MotorBehaviour : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1500f;

    void Update() {
        transform.Rotate(Vector3.forward * -_rotationSpeed * Time.deltaTime);
    }
}
