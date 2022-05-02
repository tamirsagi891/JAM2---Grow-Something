using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField] private TextMeshProUGUI score;
     public static string playerName;

    // Start is called before the first frame update
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        score.text = "" + _gameManager.Score;
        var highscoreElement = new HighScoreElement(_gameManager.PlayerName, _gameManager.Score);
        
        HighScoreHandler.AddHighscoreIfPossibol(highscoreElement);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) _gameManager.RestartGame();
    }
}