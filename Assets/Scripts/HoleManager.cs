using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public ParticleSystem ConfettiEffect;
    public static HoleManager Instance;
    void Start()
    {
        Instance = this;
        ConfettiEffect = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "ball") return;
        ConfettiEffect.Play();
        collision.gameObject.GetComponent<BallPhysicsBehaviour>().OnHoleEnter();
    }
}