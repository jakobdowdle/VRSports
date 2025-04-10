using UnityEngine;

public class MainMenuEnvironmentBehaviour : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1;

    void Update() {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * -_rotationSpeed);
    }
}
