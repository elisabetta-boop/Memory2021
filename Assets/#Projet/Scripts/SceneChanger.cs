using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Change(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadMainGame(int level) 
    {
        int row, col;
        // int row= level/3;
        switch (level) 
        {
            case 1: row= 2;
                    col = 3;
                    break;
            case 2: row= 3;
                    col = 4;
                    break;
            default: 
                    row = 4;
                    col= 5;
                    break;
        }
    

    PlayerPrefs.SetInt("row", row);
    PlayerPrefs.SetInt("col", col);
    SceneManager.LoadScene("MainScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
