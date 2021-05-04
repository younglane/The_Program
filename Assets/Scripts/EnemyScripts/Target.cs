
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    private perkTracker perkTrackr;

    public int health = 100;
    public Slider slider;
    private void Awake()
    {
        perkTrackr = GameObject.Find("PerkTracker").GetComponent<perkTracker>();
        slider.maxValue = 100;
    }
    void Update()
    {
        setHealth(health);
    }
    public void setHealth(int health)
    {

        slider.value = health;
    }
    public void TakeDamage(int amount)
    {
        perkTrackr.scoreInt += 10;
        health -= amount;
        if(health <= 0f)
        {
            perkTrackr.scoreInt += 100;
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
