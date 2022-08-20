using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isDeath = false;
    // Update is called once per frame
    void Update()
    {
        if(_isDeath == true && Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void IsGameOver()
    {
        _isDeath = true;
    }
}
