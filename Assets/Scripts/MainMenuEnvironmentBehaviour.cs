using UnityEngine;

public class MainMenuEnvironmentBehaviour : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1;

    void Update() {
        RotateEnvironment();
    }

    private void RotateEnvironment() {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
    }
}
