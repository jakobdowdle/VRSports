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
        _headPositionLast = _headPositionCurrent;
        _headPositionCurrent = _headPoint.transform.position;
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag != "ball") return;

        Vector3 swingDirection = (_headPositionCurrent - _headPositionLast).normalized;
        //Add collision force and direction to ball
        collision.gameObject.GetComponent<BallPhysicsBehaviour>().HitWithClub(swingDirection * 1000, collision.transform.position);
    }
}
