using UnityEngine;
using UnityEngine.InputSystem;

public class WristMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _wristMenu;
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
}
