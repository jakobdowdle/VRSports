using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysicsBehaviour : MonoBehaviour
{
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hitWithClub(Vector3 force, Vector3 position)
    {
        Debug.Log("HIT");
        _rb.AddForceAtPosition(force, position);
    }
}
