using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _shared;

    [SerializeField] private List<int> winterTargets = new List<int>();
    private int _yearsPassed;

    public bool IsTrowingSeed { get; set; }
    public string CurrentSeason { get; set; }
    public int Score { get; set; }
    public string PlayerName { get; set; }
    public int NextGoal { get; set; }
    public float CurrentDeg { get; set; }
    public AudioManager AudioManager { get; set; }

    private void Awake()
    {
        if (!_shared)
        {
            _shared = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        AudioManager = FindObjectOfType<AudioManager>();
        SetDefaultVariables();
    }

    private void SetDefaultVariables()
    {
        IsTrowingSeed = false;
        CurrentSeason = "Spring";
        Score = 0;
        _yearsPassed = 0;
        NextGoal = 0;
        UpdateTargetGoal();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadRules()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void LoadInput()
    {
        SceneManager.LoadScene("EnterYourName");
    }
    
    public void RestartGame()
    {
        SetDefaultVariables();
        SceneManager.LoadScene("Start");
    }

    private void UpdateTargetGoal()
    {
        if (_yearsPassed >= winterTargets.Count)
            NextGoal += (_yearsPassed - winterTargets.Count + 1) * 10;
        else
            NextGoal = winterTargets[_yearsPassed];
    }

    public void YearPassed()
    {
        if (NextGoal > Score) SceneManager.LoadScene("End");
        _yearsPassed += 1;
        UpdateTargetGoal();
    }
}