using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int _sceneNumber;
    public void LoadScene() {
        SceneManager.LoadScene(_sceneNumber);
    }
}
