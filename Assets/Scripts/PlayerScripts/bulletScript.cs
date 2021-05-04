using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int bulletSpeed;
    public int bulletDamage;

    public float bulletDespawnTimer = 5.0f;

    private void OnTriggerEnter(Collider other)
    {
        print("hit " + other.name + "!");
        Target target = other.transform.GetComponent<Target>();

        if (target != null)
        {
            target.TakeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
    private void LateUpdate()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    void Update()
    {
        if (bulletDespawnTimer > 0)
        {
            bulletDespawnTimer -= Time.deltaTime;
        }
        else Destroy(gameObject);
    }
}
