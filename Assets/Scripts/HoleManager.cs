using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class HoleManager : MonoBehaviour
{
    public ParticleSystem ConfettiEffect;
    public int par;
    [HideInInspector] public int strokes;
    [HideInInspector] public float holeDistance;
    [HideInInspector] public Vector3 BallStartPosition;
    void Awake()
    {
        ConfettiEffect = GetComponent<ParticleSystem>();
        GameObject _ballStartObject = transform.Find("BallStart").gameObject;
        BallStartPosition = _ballStartObject.transform.position;
        _ballStartObject.SetActive(false);
        holeDistance = Vector3.Distance(transform.position, BallStartPosition);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "ball") return;
        GameManager.Instance.HoleComplete();
        collision.gameObject.GetComponent<BallPhysicsBehaviour>().OnHoleEnter();
        ConfettiEffect.Play();
    }
}