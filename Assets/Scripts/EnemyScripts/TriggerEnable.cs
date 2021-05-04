using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnable : MonoBehaviour
{
    public GameObject toEnable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            toEnable.SetActive(true);
        }
    }
}
