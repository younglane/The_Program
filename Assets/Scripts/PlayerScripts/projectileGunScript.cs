using UnityEngine.UI;
using UnityEngine;

public class projectileGunScript : MonoBehaviour
{
    public GameObject projectilePrefab; //Bullet prefab
    public GameObject gunBarrel; //Gun barrel Position

    public bool debugLaser = false;
    private PlayerWeapons gunBelt;

    //Audo
    public AudioSource gunaudio;
    public AudioClip gunsound;
    public AudioClip gunswap;

    public float speed = 20;
    private void Start()
    {
        gunBelt = GetComponentInParent<PlayerWeapons>();
        gunaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (debugLaser) Aim(); //Laser for Debuging Aim from gunBarrel Position

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fireWeapon();
            gunaudio.PlayOneShot(gunsound, .2f);
        }
    }

    void fireWeapon()
    {
        if (gunBelt.ammoCount == 0)
        {
            gunaudio.PlayOneShot(gunswap, .2f);
        }
        gunBelt.ammoCount -= 1;
        GameObject bullet = Instantiate(projectilePrefab, gunBarrel.transform.position, gunBarrel.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed * Time.deltaTime);
    }

    //Debug Laser -- Click Gizmo to See in game in editer or to remove.
    void Aim()
    {
        Vector3 screenCenter = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(gunBarrel.transform.position, screenCenter, Color.green);
    }
}

