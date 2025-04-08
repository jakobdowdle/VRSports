using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GameObject> Holes;
    public List<int> Strokes;
    private int _currentHole;
    void Awake()
    {
        Instance = this;
        _currentHole = 1;
        Strokes.Add(0);
    }

    public GameObject GetCurrentHole()
    {
        return Holes[_currentHole - 1];
    }

    public void OnBallHit()
    {
        Strokes[_currentHole - 1]++;
        Debug.Log(Strokes[_currentHole - 1]);
    }

    public void HoleComplete()
    {
        _currentHole++;
        if (_currentHole <= Holes.Count)
        { 
            Strokes.Add(0);
            return;
        }

        for (int i = 0; i < Holes.Count; i++) Holes[i].GetComponent<ParticleSystem>().Play();
    }
}
