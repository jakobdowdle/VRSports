using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportToBehaviour : MonoBehaviour
{
    [SerializeField] private List<GameObject> clubs;
    public InputActionAsset inputActionAsset;
    private InputAction _teleportClubs;
    void Start()
    {
        _teleportClubs = inputActionAsset.FindAction("Teleport Club");
    }

    void Update()
    {
        if (_teleportClubs.triggered) TeleportClubsToPlayer();
    }

    public void TeleportClubsToPlayer()
    {
        float x = -0.5f;
        Vector3 currentPosition = transform.position;
        for(int i = 0; i < clubs.Count; i++)
        {
            clubs[i].transform.rotation = Quaternion.identity;
            clubs[i].transform.position = currentPosition + new Vector3(x, 0, 1);
            x += 0.5f;
        }
    }
}
