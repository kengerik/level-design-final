using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class BedroomEvent5 : MonoBehaviour
{
    public bool inside = false;
    public bool interacted = false;
    public bool journalCollect3 = false;


    //Object triggers
    public GameObject CabinIssueFix6;
    public GameObject CabinUhOh4;
    public GameObject Manual;
    public GameObject journalPage3;

    //standard interaction prompt
    public GameObject EInteract;


    //Audio triggers
    //Must be same as one activated by engine event
    public AudioSource ellaAhSoThatsHowandAnotherPage;
    public AudioSource BookGrabandSkim;
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
            Learn();

        }

        if (inside == true && journalCollect3 == true)
        {
            journalPage3.SetActive(false);
            pageGrab.Play();
            journalCollect3 = false;
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
    void Learn()
    {
        Manual.SetActive(false);
        BookGrabandSkim.Play();
        ellaAhSoThatsHowandAnotherPage.Play();
        CabinIssueFix6.SetActive(true);
        CabinUhOh4.SetActive(false);
        StartCoroutine(WaitandDoSomething(2.0f));
    }

    IEnumerator WaitandDoSomething(float secondsToWait)
    {
        Debug.Log("Starting to wait...");
        yield return new WaitForSeconds(secondsToWait); // Pause execution for 'secondsToWait'
        Debug.Log("Finished waiting! Doing cabin event now.");
        // Place the code you want to execute after the delay here
        journalCollect3 = true;
    }
}
