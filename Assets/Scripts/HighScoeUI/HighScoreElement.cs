using System;
using System.Collections;
using System.Collections.Generic;
[Serializable]
public class HighScoreElement
{
    public string playerName;
    public int points;
    

    public HighScoreElement(string name, int points)
    {
        playerName = name;
        this.points = points;
    }
}
