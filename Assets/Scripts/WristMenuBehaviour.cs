using UnityEngine;
using UnityEngine.XR;

public class WristMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _wristMenu;
    private InputDevice _controller;

    void Start() {
        // Find the input device associated with the right controller (or adjust for your specific controller)
        var leftHandController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (leftHandController.isValid) {
            _controller = leftHandController;
            Debug.Log("omar");
        }
    }

    void Update() {
        // Check if the A button is pressed
        if (_controller.isValid) {
            bool isPressed;
            if (_controller.TryGetFeatureValue(CommonUsages.primaryButton, out isPressed) && isPressed) {
                // The A button was pressed
                Debug.Log("omar");
                ToggleWristMenu();
            }
        }
    }
    private void ToggleWristMenu() {
        _wristMenu.SetActive(!_wristMenu.activeSelf);

    }
}
