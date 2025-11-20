using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class HullEvent7 : MonoBehaviour
{
    public bool inside = false;
    public bool interacted = false;
    public bool JournalCollect4 = false;


    //Object triggers
    public GameObject BurstParticles;
    public GameObject JournalPage4;
    public GameObject planks;
    public GameObject CueFinalEvent;

    //standard interaction prompt
    public GameObject EInteract;

    //Audio triggers
    public AudioSource hullPatchSound;
    public AudioSource pageGrab;
    public AudioSource ellaDespair;
    //if we choose to put an alarm here public AudioSource deepAlarmNoise;


    // Update is called once per frame
    void Update()
    {
        if (inside == true && Input.GetKey(KeyCode.E) && interacted == false)
        {
            interacted = true;
            HidePrompt();
            HullPatch();

        }

        if (inside == true && JournalCollect4 == true)
        {
            ellaDespair.Play();
            pageGrab.Play();
            JournalPage4.SetActive(false);
            JournalCollect4 = false;
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

    void HullPatch()
    {
        hullPatchSound.Play();
        planks.SetActive(true);
        BurstParticles.SetActive(false);
        CueFinalEvent.SetActive(true);

        //pause for 10 secons before doing event2
        StartCoroutine(WaitandDoSomething(2.0f));

    }

    IEnumerator WaitandDoSomething(float secondsToWait)
    {
        Debug.Log("Starting to wait...");
        yield return new WaitForSeconds(secondsToWait); // Pause execution for 'secondsToWait'
        Debug.Log("Finished waiting! Doing cabin event now.");
        // Place the code you want to execute after the delay here
        JournalCollect4 = true;
    }
}
