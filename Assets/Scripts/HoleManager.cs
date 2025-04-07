using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public ParticleSystem ConfettiEffect;
    public static HoleManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ConfettiEffect = GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "ball") return;
        ConfettiEffect.Play();
        collision.gameObject.GetComponent<BallPhysicsBehaviour>().OnHoleEnter();
    }
}