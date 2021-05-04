using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float currentHealth = 100;
    public Text healthUI;
    public Animator healthAni;
    //private Animator playerAnimator;

    private FirstPersonLook playerMouse;
    private FirstPersonMove playerWasd;

    public GameObject player;

    public GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {

        //playerAnimator = GetComponent<Animator>();
        playerMouse = player.GetComponent<FirstPersonLook>();
        playerWasd = player.GetComponent<FirstPersonMove>();
        playerMouse.isPlaying = true;
        playerWasd.canMove = true;

        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //playerAnimator.SetBool("isDead", true);
            playerMouse.isPlaying = false;  // Kills player movement while menu open
            playerWasd.canMove = false;

            gameOverMenu.SetActive(true);
        }

        healthUI.text = "Health: " + currentHealth.ToString();
    }

    public void takeDamage(int enemyDamage)
    {
        currentHealth -= enemyDamage;
        healthAni.SetBool("take damage", true);
        StartCoroutine(stopHealthFlash());

    }

    IEnumerator stopHealthFlash()
    {
        yield return new WaitForSeconds(0.5f);
        healthAni.SetBool("take damage", false);

    }
}
