using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    private Animator anim;

    public float speed = 10;

    //Audio
    private AudioSource enemyAudio;
    public AudioClip audioidle;
    public AudioClip audioatk;
    public AudioClip audiodie;

    //Sight
    public float heightMultiplier;
    public float sightDist = 10;

    public GameObject targetPlayer;

    public enum Status
    {
        INVESTIGATE,
        ATTACK
    }

    public Status status;

    public int attackDistance = 2;
    public int enemyDamage = 10;
    public int knockback = 5;
    private bool attacking = false;
    
    // Start is called before the first frame update
    void Start()
    {
        heightMultiplier = 1.36f;
        status = Enemy.Status.INVESTIGATE;
        anim = GetComponent<Animator>();
        targetPlayer = GameObject.FindWithTag("Player");
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(enemyActions());
    }

    
    IEnumerator enemyActions()
    {
        switch(status)
        {
            case Status.INVESTIGATE:
                investigate();
                break;

            case Status.ATTACK:
                attack();
                break;
        }
        yield return null;
    }

    void investigate()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized * sightDist, Color.green);

        if(Physics.Raycast (transform.position + Vector3.up * heightMultiplier, transform.forward, out hit, sightDist))
        {
            //enemyAudio.PlayOneShot(audioidle, 0.1f);
            if (hit.collider.gameObject.tag == "Player")
            {
                status = Enemy.Status.ATTACK;
                enemyAudio.PlayOneShot(audioidle, 0.1f);
                Debug.Log("Detected");
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                status = Enemy.Status.ATTACK;
                enemyAudio.PlayOneShot(audioidle, 0.1f);
                Debug.Log("Detected");
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized, out hit, sightDist))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                status = Enemy.Status.ATTACK;
                enemyAudio.PlayOneShot(audioidle, 0.1f);
                Debug.Log("Detected");
            }
        }
    }

    void attack()
    {
        transform.LookAt(targetPlayer.transform.position);
        transform.position += transform.forward * speed * Time.deltaTime;
        anim.SetBool("See player", true);
        if (Vector3.Distance(transform.position, targetPlayer.transform.position) < attackDistance)
        {
            enemyAudio.PlayOneShot(audioatk, 0.1f);
            anim.SetBool("In range", true);
            StartCoroutine(waitForAttack());
        }
        else
        {
            anim.SetBool("In range", false);
            attacking = false;
        }
    }

    IEnumerator waitForAttack()
    {
        attacking = true;
        yield return new WaitForSeconds(0.5f);
        attacking = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(attacking && collision.collider.gameObject.CompareTag("Player"))
        {
            Vector3 direction = (transform.position - targetPlayer.transform.position).normalized;

            targetPlayer.GetComponent<PlayerHealth>().takeDamage(enemyDamage);

            //targetPlayer.GetComponent<Rigidbody>().AddForce(direction * -knockback);
        }
    }
}
