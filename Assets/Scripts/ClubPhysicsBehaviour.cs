using System.Collections;
using UnityEngine;

public class ClubPhysicsBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _headPoint;
    [SerializeField] private float _clubHitForce;
    [SerializeField, Range(0, 1)] private float _angleCorrectionPercentage;
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

        //if (_onCoolDown) return;
        StartCoroutine(HitCooldown());

        BallPhysicsBehaviour ball = collision.gameObject.GetComponent<BallPhysicsBehaviour>();

        Vector3 holeDirection = (HoleManager.Instance.transform.position - ball.transform.position).normalized;
        Vector3 swingDirection = (_headPositionCurrent - _headPositionLast).normalized;
        Vector3 launchDirection = Vector3.Lerp(swingDirection, holeDirection, _angleCorrectionPercentage);
        launchDirection += Vector3.up / 2;

        Debug.Log(holeDirection);
        Debug.Log(swingDirection);
        Debug.Log(launchDirection);

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
