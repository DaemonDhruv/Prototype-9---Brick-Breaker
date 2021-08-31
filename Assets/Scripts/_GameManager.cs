using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class _GameManager : MonoBehaviour
{
    public static _GameManager Instance;

    public string playerName = "Anonymous";
    public List<HighscoreRecord> highScores;
    public int bestScore = 0;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


        LoadData();
    }


    public void SetPlayerName(string name)
    {
        this.playerName = name;
    }

    public void SaveHighscore(int score)
    {
        if(highScores.Count <= 5)
        {
            highScores.Add(new HighscoreRecord(playerName, score));
        } else
        {
            int indexOfLowest = 0;
            HighscoreRecord lowest = highScores[indexOfLowest];

            for(int i = 0; i < highScores.Count; i++)
            {
                if(highScores[i].score < lowest.score)
                {
                    lowest = highScores[i];
                    indexOfLowest = i;
                }
            }

            if(score >= highScores[indexOfLowest].score)
            {
                highScores[indexOfLowest] = new HighscoreRecord(playerName, score);
            }
            
        }
    }

    public void SaveData()
    {
        Highscores data = new Highscores();
        
        if(highScores.Count > 1)
        {
            // Sorting list in place
            highScores.Sort((x, y) => y.score.CompareTo(x.score));
        }

        data.lastPlayerName = playerName;
        data.highscores = highScores;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/brickbreaker.json", json);
    }



    public void LoadData()
    {
        // Let there be an empty list.
        highScores = new List<HighscoreRecord>();

        string path = Application.persistentDataPath + "/brickbreaker.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Highscores highscoreData = JsonUtility.FromJson<Highscores>(json);

            playerName = highscoreData.lastPlayerName;
            highScores = highscoreData.highscores;
        }
    }
}
