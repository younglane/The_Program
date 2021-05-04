using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float waitTime = 0.5f;
    public float rnge = 7.31f;
    public GameObject gObj;

    private Light gLight;
    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        isOn = true;
        gLight = gObj.GetComponent<Light>();

        StartCoroutine(blinking());
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn) gLight.range = rnge;
        else gLight.range = 0;
    }

    IEnumerator blinking()
    {
        isOn = true;
        yield return new WaitForSeconds(waitTime);
        isOn = false;
        yield return new WaitForSeconds(waitTime);

        StartCoroutine(blinking());
    }
}
