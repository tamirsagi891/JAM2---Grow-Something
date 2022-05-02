using UnityEngine;

public class StartGame : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.AudioManager.PlaySound("Theme");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _gameManager.LoadInput();
        if (Input.GetKeyDown(KeyCode.I)) _gameManager.LoadRules();
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
}