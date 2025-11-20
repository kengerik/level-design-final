using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class EngineEvent : MonoBehaviour
{
    public bool inside = false;
    public bool interacted = false;
    public bool journalCollect2 = false;


    //Object triggers
    public GameObject cabinEvent4;
    public ParticleSystem Smoke;
    public GameObject BreakerSparks;
    public GameObject closedBreakerBox;
    public GameObject openBreakerBox;
    public GameObject JournalPage2;

    //standard interaction prompt
    public GameObject EInteract;


    //Audio triggers
    public AudioSource EngineFix;
    public AudioSource AlarmSound2;
    public AudioSource sparkNoise;
    public AudioSource ellaFindsPage2;
    public AudioSource pageGrab;

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
            FixEngine();

        }

        if (inside == true && journalCollect2 == true)
        {
            pageGrab.Play();
            JournalPage2.SetActive(false);
            journalCollect2 = false;
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
    void FixEngine()
    {
        closedBreakerBox.SetActive(false);
        openBreakerBox.SetActive(true);
        JournalPage2.SetActive(true);
        Smoke.Stop();

        //Audio cues
        EngineFix.Play();
        sparkNoise.Stop();
        ellaFindsPage2.Play();

        StartCoroutine(WaitandDoSomethingFirst(3.0f));

        //Wait 13 seconds before starting event3
        StartCoroutine(WaitandDoSomething(13.0f));

    }

    IEnumerator WaitandDoSomethingFirst(float secondsToWait)
    {
        Debug.Log("Starting to wait...");
        yield return new WaitForSeconds(secondsToWait); // Pause execution for 'secondsToWait'
        Debug.Log("Finished waiting! Doing cabin event now.");
        // Place the code you want to execute after the delay here
        BreakerSparks.SetActive(false);
        journalCollect2 = true;
    }

    IEnumerator WaitandDoSomething(float secondsToWait)
    {
        Debug.Log("Starting to wait...");
        yield return new WaitForSeconds(secondsToWait); // Pause execution for 'secondsToWait'
        Debug.Log("Finished waiting! Doing cabin event now.");
        // Place the code you want to execute after the delay here
        cabinEvent4.SetActive(true);
        AlarmSound2.Play();
    }
}
