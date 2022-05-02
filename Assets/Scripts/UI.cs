using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private TextMeshProUGUI _curScore;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        _curScore.text = _gameManager.Score + " / " + _gameManager.NextGoal;
    }
}
