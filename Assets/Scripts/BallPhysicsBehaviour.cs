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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitWithClub(Vector3 force, Vector3 position)
    {
        Debug.Log("HIT");
        _rigidBody.AddForceAtPosition(force, position);
    }
}
