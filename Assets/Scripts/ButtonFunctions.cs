using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gameOverMenu;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void closeGame()
    {
        Application.Quit();
    }

    public void playGame()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void retunToMenu()
    {
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}