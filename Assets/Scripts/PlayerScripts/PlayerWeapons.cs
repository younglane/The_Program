using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class PlayerWeapons : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject[] projectiles;
    public int ammoCount;
    public int maxAmmo;
    public Text ammo;

    private GameObject randomGun;

    public Animator ammoBlink;
    private bool hasGun = false;

    private void Awake()
    {
        ammoCount = (Random.Range(5, maxAmmo / 2));
        RandomStartGun();
    }

    private void Update()
    {
        if (ammoCount == 1)
        {
            hasGun = false;
        }
        else if (hasGun == false && ammoCount <= 0)
        {
            Destroy(randomGun);
            StartCoroutine(RandomGunSelect());
            ammoBlink.SetBool("new weapon", true);
            ammo.text = "0/" + maxAmmo.ToString();
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(hasGun == true)
            ammo.text = ammoCount.ToString() + "/" + maxAmmo.ToString();
    }

    void RandomStartGun()
    {
        hasGun = true;
        randomGun = Instantiate(weapons[Random.Range(0, weapons.Length)], transform.position, transform.rotation);
        randomGun.transform.parent = gameObject.transform;
    }

    IEnumerator RandomGunSelect()
    {   
        hasGun = true;
        yield return new WaitForSeconds(Random.Range(.5f, 2.5f));
        randomGun = Instantiate(weapons[Random.Range(0, weapons.Length)], transform.position, transform.rotation);
        randomGun.transform.parent = gameObject.transform;
        ammoCount += Random.Range(8, maxAmmo / 2);
        yield return new WaitForSeconds(.5f);
        ammoBlink.SetBool("new weapon", false);
    }
}
