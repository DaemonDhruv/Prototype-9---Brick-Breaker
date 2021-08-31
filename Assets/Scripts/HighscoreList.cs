using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//[DefaultExecutionOrder(1000)]
public class HighscoreList : MonoBehaviour
{
    [SerializeField] GameObject rowPrefab;
    List<GameObject> rows;
    List<HighscoreRecord> highScores;

    // Start is called before the first frame update
    void Start()
    {
        rows = new List<GameObject>();
        highScores = _GameManager.Instance.highScores; //new List<HighscoreRecord>(_GameManager.Instance.highScores); // was getting a NullReferenceException

        CreateRows();
    }

    void CreateRows()
    {
        float yPos = -20;

        for(int i = 0; i < highScores.Count || i < 5; i++)
        {
            var row = Instantiate(rowPrefab);

            // This row is a child of Records Panel
            row.transform.SetParent(transform);
            
            // Shift each new row down by 60 units
            yPos += -60;
            row.transform.localPosition = new Vector3(row.transform.position.x, yPos, row.transform.position.z);

            rows.Add(row);
        }

        UpdateData();
    }

    void UpdateData()
    {
        int i = 0;
        
        foreach(GameObject row in rows) 
        {
            // to avoid index out of range error if data items are less than rows
            var name = "...";
            var score = "...";

            if (i < highScores.Count)
            {
                name = highScores[i].playerName;
                score = highScores[i].score.ToString();
            }


            row.transform.Find("Name").GetComponent<TextMeshProUGUI>().SetText(name);
            row.transform.Find("Score").GetComponent<TextMeshProUGUI>().SetText(score);
            i++;
        }
    }


}
