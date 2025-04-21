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
        Vector3 launchVelocity = GetLaunchVelocity(ball);
        ball.HitWithClub(launchVelocity, collision.transform.position);
    }
    private Vector3 GetLaunchVelocity(BallPhysicsBehaviour ball)
    {
        Vector3 holeDirection = (ball.transform.position - GameManager.Instance.GetCurrentHoleManager().transform.position).normalized;
        Vector3 swingVelocity = _headPositionCurrent - _headPositionLast;
        Vector3 swingDirection = (swingVelocity).normalized;
        Vector3 launchDirection = Vector3.Lerp(swingDirection, holeDirection, _angleCorrectionPercentage);
        float scaledMultiplier = Mathf.Lerp(0.25f, 2f, Mathf.InverseLerp(0.01f, 0.25f, swingVelocity.magnitude));
        float hitForce = _clubHitForce * (scaledMultiplier);
        Vector3 launchVelocity = (launchDirection * hitForce) + (Vector3.up * (_upwardAngleAdjustmentPercentage * scaledMultiplier));
        return launchVelocity;
    }
    private IEnumerator HitCooldown()
    {
        _onCoolDown = true;
        yield return new WaitForSeconds(1);
        _onCoolDown = false;
    }
}
