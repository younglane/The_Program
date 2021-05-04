using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// IMPORTANT:
// Because we reload the player object for every scene,
// the object attached to this script will not be reloaded
// and will be used to update the player's stats according
// to their accumulated perks at the beginning of each level.

public class perkTracker : MonoBehaviour
{
    public float hpBonus = 0f;      // Additional HP
    public float speedBonus = 0f;   // Additional speed
    public float dashBonus = 0f;    // Dash speed bonus
    public float dashDist = 0f;     // Dash distance bonus
    public float gravReduct = 0f;   // Gravity reduction(/addition)

    public float startingHP = 0f;   // HP for player to start at next level

    public GameObject perkTrackerObj;

    public GameObject player;
    private FirstPersonMove playerMove;
    private PlayerHealth playerHlth;

    private GameObject score;       // Scoring stuff
    private Text scoreText;
    public int scoreInt = 0;

    private string refSceneName;    // For tracking the current scene
    private string sceneName;       // against the recorded name
    private float maxHP = 200;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); // Finds player gameobject
        score = GameObject.Find("Score");   // Finds score gameobject
        scoreText = score.GetComponent<Text>();

        scoreText.text = scoreInt + " pts";

        DontDestroyOnLoad(perkTrackerObj);
        refSceneName = SceneManager.GetActiveScene().name;
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;
        scoreText.text = scoreInt + " pts";  // Keeps score updated

        if (!sceneName.Equals(refSceneName)) // New scene loaded
        {
            Debug.Log("New scene detected!");
            refSceneName = SceneManager.GetActiveScene().name;
            player = GameObject.Find("Player"); // Finds player gameobject
            score = GameObject.Find("Score");   // Finds score gameobject
            scoreText = score.GetComponent<Text>();
            applyPerks();
        }
    }

    // Applies bonus attributes to player
    void applyPerks()
    {
        playerMove = player.GetComponent<FirstPersonMove>();
        playerHlth = player.GetComponent<PlayerHealth>();

        scoreInt += (int)playerHlth.currentHealth * 10;

        maxHP = 200 + hpBonus; // Changes max HP
        playerMove.speed += speedBonus; // Speed bonus
        if (startingHP <= maxHP) playerHlth.currentHealth = startingHP; // Adds additional HP
        else playerHlth.currentHealth = maxHP;
        playerMove.dashSpeed += dashBonus; // Dash bonus
        playerMove.dashTime += dashDist; // Dash distance
        playerMove.gravity += gravReduct; // Gravity
    }
}
