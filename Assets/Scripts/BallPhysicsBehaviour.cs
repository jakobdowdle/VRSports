using System.Collections;
using UnityEngine;

public class BallPhysicsBehaviour : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Renderer _objectRenderer;
    private TrailRenderer _trailRenderer;
    [SerializeField] private float _respawnTimer;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _objectRenderer = GetComponent<Renderer>();
        _trailRenderer = GetComponent<TrailRenderer>();
        transform.position = GameManager.Instance.GetCurrentHole().GetComponent<HoleManager>().BallStartPosition;
    }

    public void HitWithClub(Vector3 force, Vector3 position)
    {
        _rigidBody.AddForceAtPosition(force, position);
    }

    public void OnHoleEnter()
    {
        _objectRenderer.enabled = false;
        _rigidBody.velocity = Vector3.zero;
        _trailRenderer.enabled = false;
        StartCoroutine(waitAndSpawnAtNextHole());
    }

    private IEnumerator waitAndSpawnAtNextHole()
    {
        yield return new WaitForSeconds(_respawnTimer);
        transform.position = GameManager.Instance.GetCurrentHole().GetComponent<HoleManager>().BallStartPosition;
        _objectRenderer.enabled = true;
        _trailRenderer.enabled = true;
    }
}
