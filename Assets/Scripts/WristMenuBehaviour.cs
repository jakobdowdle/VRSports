using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class WristMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _wristMenu;
    [SerializeField] private TextMeshProUGUI _holeText;
    [SerializeField] private TextMeshProUGUI _parText;
    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public InputActionAsset inputActionAsset;
    private InputAction _openMenu;

    void Start() {
        _openMenu = inputActionAsset.FindAction("Open Menu");
    }

    void Update() {
        if (_openMenu.triggered) ToggleWristMenu();
    }

    private void ToggleWristMenu() {
        _wristMenu.SetActive(!_wristMenu.activeSelf);

    }

    public void UpdateMenu() {
        _holeText.text = "Hole " + 2;
    }
}
