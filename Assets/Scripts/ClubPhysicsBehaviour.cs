using System.Collections;
using UnityEngine;

public class ClubPhysicsBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _headPoint;
    [SerializeField] private float _clubHitForce;
    [SerializeField, Range(0, 1)] private float _angleCorrectionPercentage, _upwardAngleAdjustmentPercentage;
    private Vector3 _headPositionLast, _headPositionCurrent;
    private bool _onCoolDown;

    private void FixedUpdate()
    {
        _headPositionLast = _headPositionCurrent;
        _headPositionCurrent = _headPoint.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "ball") return;

        if (_onCoolDown) return;
        StartCoroutine(HitCooldown());

        GameManager.Instance.OnBallHit();

        BallPhysicsBehaviour ball = collision.gameObject.GetComponent<BallPhysicsBehaviour>();

        Vector3 holeDirection = (ball.transform.position - GameManager.Instance.GetCurrentHoleManager().transform.position).normalized;
        Vector3 swingDirection = (_headPositionCurrent - _headPositionLast).normalized;
        Vector3 launchDirection = Vector3.Lerp(swingDirection, holeDirection, _angleCorrectionPercentage);
        launchDirection += Vector3.up * _upwardAngleAdjustmentPercentage;

        //Add collision force and direction to ball
        ball.HitWithClub(launchDirection * _clubHitForce, collision.transform.position);
    }

    private IEnumerator HitCooldown()
    {
        _onCoolDown = true;
        yield return new WaitForSeconds(2);
        _onCoolDown = false;
    }
}
