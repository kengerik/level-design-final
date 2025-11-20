using System.Collections;
using UnityEngine;

public class FinalEvent : MonoBehaviour
{
    public bool inside = false;
    public bool interacted = false;


    //Object triggers
    public GameObject Monster;
    public GameObject UIBlack;

    //Audio triggers
    //Must be same as one activated by engine event
    public AudioSource MonsterAttack;
    public AudioSource ellaScream;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inside == true && interacted == false)
        {
            interacted = true;
            Death();

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
    }

    void HidePrompt()
    {

    }

    //what actually happens upon successful input
    void Death()
    {
        Monster.SetActive(true);
        ellaScream.Play();
        MonsterAttack.Play();

        //Depends on length of monster animation/sounds and scream sounds
        StartCoroutine(WaitandDoSomething(2.0f));
    }

    IEnumerator WaitandDoSomething(float secondsToWait)
    {
        Debug.Log("Starting to wait...");
        yield return new WaitForSeconds(secondsToWait); // Pause execution for 'secondsToWait'
        Debug.Log("Finished waiting! Doing cabin event now.");
        // Place the code you want to execute after the delay here
        UIBlack.SetActive(true);
    }
}
