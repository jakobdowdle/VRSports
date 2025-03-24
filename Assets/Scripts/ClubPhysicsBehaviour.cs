using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubPhysicsBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _headPoint; 
    private Vector3 _headPositionLast;
    private Vector3 _headPositionCurrent;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _headPositionLast = new Vector3(_headPositionCurrent.x, _headPositionCurrent.y, _headPositionCurrent.z);
        _headPositionCurrent = new Vector3(_headPoint.transform.position.x, _headPoint.transform.position.y, _headPoint.transform.position.z);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag != "ball") return;

        //Direction club is swinging
        Vector3 swingDirection = _headPositionCurrent - _headPositionLast;
        //Add collision force and direction to ball
        collision.gameObject.GetComponent<BallPhysicsBehaviour>().hitWithClub(swingDirection * 1000, collision.transform.position);
    }

}
