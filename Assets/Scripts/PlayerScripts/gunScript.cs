//Hit Scan//
using UnityEngine;
using UnityEngine.UI;

public class gunScript : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public int maxAmmo;
    public int ammo;
    public ParticleSystem muzzle;
    public GameObject impactEffect;
    public float fireRate = 15f;
    public Camera fpsCam;
    public Text ammoCount;


    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {
        ammoCount.text = ammo.ToString() + "/" + maxAmmo.ToString();

        
        if (Input.GetButton("Fire1") && (Time.time >= nextTimeToFire) && (ammo > 0))
        {
            ammo--;
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (ammo == 0)
        {
            ammoCount.color = Color.red;
            Debug.Log("Out of ammo");
        }
    }
    void Shoot()
    {
        muzzle.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObject, 1f);
        }
    }

}
