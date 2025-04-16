using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private List<HoleManager> _holes;
    private int _currentHole;
    void Awake()
    {
        Instance = this;
        _currentHole = 1;
    }

    public HoleManager GetCurrentHoleManager() => _holes[_currentHole - 1];
    public int GetCurrentHoleNumber() => _currentHole;

    public int GetScore()
    {
        int score = 0;
        for (int i = 0; i < _holes.Count; i++)
        {
            score += _holes[i].strokes;
        }
        _holes[0].strokes += 5;
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
        if (_currentHole <= _holes.Count) return; 
        PlayConfettiOnAllHoles();
    }

    public void PlayConfettiOnAllHoles()
    {
        for (int i = 0; i < _holes.Count; i++) _holes[i].ConfettiEffect.Play();
    }
}
