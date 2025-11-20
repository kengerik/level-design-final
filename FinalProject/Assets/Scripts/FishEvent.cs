using System;
using System.Collections;
using UnityEngine;

public class FishEvent : MonoBehaviour
{
    public bool inside = false;
    public bool interacted = false;
    public bool JournalCollect = false;


    //Object triggers
    public GameObject CabinEvent;
    public GameObject SilverFish;
    public GameObject Journal;

    //standard interaction prompt
    public GameObject EInteract;

    //Audio triggers
    public AudioSource reelnoise;
    public AudioSource alarmnoise;
    public AudioSource EllaFishLine;
    public AudioSource EllaFindsJournalAudio;
    public AudioSource sparkNoise;

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
            ReelUp();
            
        }

        if (inside == true && JournalCollect == true)
        {
            EllaFindsJournalAudio.Play();
            Journal.SetActive(false);
            JournalCollect = false;
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

    void ReelUp()
    {
        reelnoise.Play();
        SilverFish.SetActive(true);
        EllaFishLine.Play();
        //pause for 10 secons before doing event2
        StartCoroutine(WaitandDoSomething(15.0f));
        
    }

    IEnumerator WaitandDoSomething(float secondsToWait)
    {
        Debug.Log("Starting to wait...");
        yield return new WaitForSeconds(secondsToWait); // Pause execution for 'secondsToWait'
        Debug.Log("Finished waiting! Doing cabin event now.");
        // Place the code you want to execute after the delay here
        CabinEvent.SetActive(true);
        alarmnoise.Play();
        sparkNoise.Play();
        JournalCollect = true;
    }
}
