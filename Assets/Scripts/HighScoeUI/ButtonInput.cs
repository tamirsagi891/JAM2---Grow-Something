using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) StartCoroutine(ChangeToScene());
    }
    
    public IEnumerator ChangeToScene()
    {
        yield return new WaitForSeconds(1.5f);
        _gameManager.StartGame();
    }
    
    
}
