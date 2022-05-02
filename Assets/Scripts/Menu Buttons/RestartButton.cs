using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    private GameManager _gameManager;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) _gameManager.RestartGame();
        
    }
}
