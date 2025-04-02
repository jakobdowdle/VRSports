using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysicsBehaviour : MonoBehaviour
{
    private Rigidbody _rigidBody;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void HitWithClub(Vector3 force, Vector3 position)
    {
        _rigidBody.AddForceAtPosition(force, position);
    }

    public void OnHoleEnter()
    {
        gameObject.SetActive(false);
    }
}
