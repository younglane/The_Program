using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victoryscreen : MonoBehaviour

    
{
    public GameObject[] boss;
    public GameObject player;
    public GameObject vScreen;
    public Text scre;
    public Text RefScore;

    private FirstPersonLook pLook;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectsWithTag("Enemy");
        pLook = player.GetComponent<FirstPersonLook>();
        scre.text = RefScore.text;
    }

    // Update is called once per frame
    void Update()
    {
        boss = GameObject.FindGameObjectsWithTag("Enemy");

        if (boss == null || boss.Length == 0)
        {
            pLook.isPlaying = false;
            vScreen.SetActive(true);
        }
    }
}
