using System.Collections;
using UnityEngine;

public class BallPhysicsBehaviour : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Renderer _objectRenderer;
    private TrailRenderer _trailRenderer;
    [SerializeField] private float _respawnTimer;
    public static Vector3 Position;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _objectRenderer = GetComponent<Renderer>();
        _trailRenderer = GetComponent<TrailRenderer>();
        transform.position = GameManager.Instance.GetCurrentHoleManager().GetComponent<HoleManager>().BallStartPosition;
    }

    private void Update()
    {
        Position = transform.position;
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
        StartCoroutine(WaitAndSpawnAtNextHole());
    }

    private IEnumerator WaitAndSpawnAtNextHole()
    {
        yield return new WaitForSeconds(_respawnTimer);
        transform.position = GameManager.Instance.GetCurrentHoleManager().GetComponent<HoleManager>().BallStartPosition;
        _objectRenderer.enabled = true;
        _trailRenderer.enabled = true;
    }
}
