using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;

public class WristMenuBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _wristMenu;
    [SerializeField] private TextMeshProUGUI _holeText;
    [SerializeField] private TextMeshProUGUI _parText;
    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _strokeCounter;

    public InputActionAsset inputActionAsset;
    private InputAction _openMenu;

    private GameManager _gameManager;

    void Start() {
        _openMenu = inputActionAsset.FindAction("Open Menu");
        _gameManager = GameManager.Instance;
    }

    void Update() {
        if (_openMenu.triggered) ToggleWristMenu();
        if (_wristMenu.activeSelf) UpdateMenu();
    }

    private void ToggleWristMenu() {
        _wristMenu.SetActive(!_wristMenu.activeSelf);

    }

    public void UpdateMenu() {
        _holeText.text = "Hole " + _gameManager.GetCurrentHoleNumber();
        _parText.text = "Par " + _gameManager.GetCurrentHoleManager().par;
        _distanceText.text = _gameManager.GetCurrentHoleManager().holeDistance + " meters";
        _scoreText.text = _gameManager.GetScore() + "";
        _strokeCounter.text = _gameManager.GetCurrentHoleManager().strokes + "";
    }
}
