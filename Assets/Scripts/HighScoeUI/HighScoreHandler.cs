using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHandler : MonoBehaviour
{
    private static List<HighScoreElement> highScoreList = new List<HighScoreElement>();
    [SerializeField] private static int maxCount = 3;
    [SerializeField] private static string filename ="highscores.json";
    public delegate void OnHighScoreListChanged(List<HighScoreElement> list);

    public static event OnHighScoreListChanged onHighScoreListChanged;
    void Start()
    {
        LoadHighScores();
    }

    // Update is called once per frame
    private void LoadHighScores()
    {
        highScoreList = FileHandler.ReadListFromJSON<HighScoreElement>(filename);
        while (highScoreList.Count > maxCount)
        {
            highScoreList.RemoveAt(maxCount);
        }

        if (onHighScoreListChanged != null)
        {
            onHighScoreListChanged.Invoke(highScoreList);
        }
    }

    private static void SavedHighScore()
    {
        FileHandler.SaveToJSON<HighScoreElement> (highScoreList, filename);
    }

    public static void AddHighscoreIfPossibol(HighScoreElement element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (i >= highScoreList.Count || element.points > highScoreList[i].points)
            {
                //add new high score
                highScoreList.Insert(i,element);
                while (highScoreList.Count > maxCount)
                {
                    highScoreList.RemoveAt(maxCount);
                }
                SavedHighScore();
                if (onHighScoreListChanged != null)
                {
                    onHighScoreListChanged.Invoke(highScoreList);
                }
                break;
            }
        }
    }
}
