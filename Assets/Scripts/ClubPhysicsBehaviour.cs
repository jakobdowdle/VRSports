using UnityEngine;

public class ClubPhysicsBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _headPoint;
    [SerializeField] private float _clubHitForce;
    [SerializeField] private float _angleCorrectionPercentage;
    private Vector3 _headPositionLast;
    private Vector3 _headPositionCurrent;

    private void FixedUpdate()
    {
        _headPositionLast = _headPositionCurrent;
        _headPositionCurrent = _headPoint.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "ball") return;

        BallPhysicsBehaviour ball = collision.gameObject.GetComponent<BallPhysicsBehaviour>();

        Vector3 holeDirection = (ball.transform.position - HoleManager.Instance.transform.position).normalized;
        Vector3 swingDirection = (_headPositionCurrent - _headPositionLast).normalized;
        Vector3 launchDirection = Vector3.Lerp(swingDirection, holeDirection, _angleCorrectionPercentage);
        
        //Add collision force and direction to ball
        ball.HitWithClub(launchDirection * _clubHitForce, collision.transform.position);
    }
}
