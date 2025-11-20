using System;
using System.Collections;
using UnityEngine;

public class CabinEvent : MonoBehaviour
{
    public bool inside = false;
    public bool interacted = false;


    //Object triggers
    public GameObject EngineEvent3;
    public GameObject Sparks;
    public GameObject SilverFish;
    public GameObject journal;
    //shorter fishing line
    public GameObject line2;
    //default longer fishinf line
    public GameObject line1;

    //standard interaction prompt
    public GameObject EInteract;


    //Audio triggers
    public AudioSource Sparknoise;
    public AudioSource alarmnoise;
    public AudioSource fixnoise;
    public AudioSource EngineBreak;

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
            Fix();
            
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
    void Fix()
    {
        fixnoise.Play();
        Sparks.SetActive(false);
        SilverFish.SetActive(false);
        journal.SetActive(true);
        line2.SetActive(true);
        line1.SetActive(false);
        alarmnoise.Stop();
        Sparknoise.Stop();

        //Wait 25 seconds before starting event3
        StartCoroutine(WaitandDoSomething(25.0f));

    }

    IEnumerator WaitandDoSomething(float secondsToWait)
    {
        Debug.Log("Starting to wait...");
        yield return new WaitForSeconds(secondsToWait); // Pause execution for 'secondsToWait'
        Debug.Log("Finished waiting! Doing cabin event now.");
        // Place the code you want to execute after the delay here
        EngineEvent3.SetActive(true);
        EngineBreak.Play();
    }
}
