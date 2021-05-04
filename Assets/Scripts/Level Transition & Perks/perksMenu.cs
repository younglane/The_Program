using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class perksMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject perkMenu;

    private string sceneName;
    private string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        getNextSceneName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName); // Loads next scene
    }

    void getNextSceneName()
    {
        switch (sceneName)
        {
            case "LevelOne":
                nextSceneName = "LevelTwo";
                break;
            case "LevelTwo":
                nextSceneName = "LevelThree";
                break;
            case "LevelThree":
                nextSceneName = "LevelFour";
                break;
            case "LevelFour":
                nextSceneName = "LevelFive";
                break;
        }
    }
}
