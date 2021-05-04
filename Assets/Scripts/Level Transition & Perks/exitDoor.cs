using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitDoor : MonoBehaviour
{
    public GameObject doorOn;
    public GameObject player;

    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); // List of enemies
        doorOn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Length == 0 || enemies == null) // Waits for enemy count to hit 0
        {
            doorOn.SetActive(true);
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
