using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class WristMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _wristMenu;
    private InputDevice _controller;
    public InputActionAsset inputActionAsset;
    private InputAction _openMenu;

    void Start() {
        _openMenu = inputActionAsset.FindAction("Open Menu");
    }

    void Update() {
        if (_openMenu.triggered)
        {
            //Debug.Log(_wristMenu.activeSelf);
            ToggleWristMenu();
        }
        //Debug.Log(_wristMenu.activeSelf);

    }
    private void ToggleWristMenu() {
        //Debug.Log(_wristMenu.activeSelf);
        _wristMenu.SetActive(!_wristMenu.activeSelf);

    }
}
