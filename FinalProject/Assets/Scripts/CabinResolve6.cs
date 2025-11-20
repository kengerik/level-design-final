using System.Collections;
using UnityEditor.Compilation;
using UnityEngine;

public class CabinResolve6 : MonoBehaviour
{
    public bool inside = false;
    public bool interacted = false;


    //Object triggers
    public GameObject HullEvent7;
    public GameObject ErrorLight;

    //standard interaction prompt
    public GameObject EInteract;


    //Audio triggers
    //Must be same as one activated by engine event
    public AudioSource Alarmnoise2;
    public AudioSource BANGCREAK;
    public AudioSource mechanicalFix;
    public AudioSource floodNoise;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inside == true && Input.GetKey(KeyCode.E) && interacted == false)
        {
            interacted = true;
            HidePrompt();
            Resolve();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inside = true;
            ShowPrompt();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inside = false;
            HidePrompt();
        }
    }

    void ShowPrompt()
    {
        //UI activation that says press E to reel up
        if (interacted == false)
        {
            EInteract.SetActive(true);
        }
    }

    void HidePrompt()
    {
        EInteract.SetActive(false);
    }

    //what actually happens upon successful input
    void Resolve()
    {
        ErrorLight.SetActive(false);
        Alarmnoise2.Stop();

        StartCoroutine(WaitandDoSomething(18.0f));
    }

    IEnumerator WaitandDoSomething(float secondsToWait)
    {
        Debug.Log("Starting to wait...");
        yield return new WaitForSeconds(secondsToWait); // Pause execution for 'secondsToWait'
        Debug.Log("Finished waiting! Doing cabin event now.");
        // Place the code you want to execute after the delay here
        BANGCREAK.Play();
        HullEvent7.SetActive(true);
    }
}
