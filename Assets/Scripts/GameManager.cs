using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GameObject> Holes;
    private int _currentHole;
    void Awake()
    {
        Instance = this;
        _currentHole = 1;
    }

    public HoleManager GetCurrentHoleManager()
    {
        return Holes[_currentHole - 1].GetComponent<HoleManager>();
    }

    public GameObject GetCurrentHoleGameObject()
    {
        return Holes[_currentHole - 1];
    }

    public int GetCurrentHoleNumber()
    {
        return _currentHole;
    }

    public int GetScore()
    {
        int score = 0;
        for (int i = 0; i < Holes.Count; i++) score += Holes[i].GetComponent<HoleManager>().strokes;
        return score;
    }

    public void OnBallHit()
    {
        GetCurrentHoleManager().strokes++;
        Debug.Log(GetCurrentHoleManager().strokes);
    }

    public void HoleComplete()
    {
        _currentHole++;
        if (_currentHole <= Holes.Count){ return; }
        
        PlayConfettiOnAllHoles();
    }

    public void PlayConfettiOnAllHoles()
    {
        for (int i = 0; i < Holes.Count; i++) Holes[i].GetComponent<ParticleSystem>().Play();
    }
}
