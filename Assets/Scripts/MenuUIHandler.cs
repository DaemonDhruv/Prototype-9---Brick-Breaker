using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


#if UNITY_EDITOR  
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    private TMP_InputField inputField;

    private void Start()
    {
        inputField = GameObject.Find("Player Name").GetComponent<TMP_InputField>();
        inputField.text = _GameManager.Instance.playerName;
    }

    public void UpdateName()
    {
        string playerName = inputField.text;
        if(playerName == "")
        {
            playerName = "Anonymous";
        }
        _GameManager.Instance.bestScore = 0;    
        _GameManager.Instance.SetPlayerName(playerName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        _GameManager.Instance.SaveData();

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif  
    }
}
