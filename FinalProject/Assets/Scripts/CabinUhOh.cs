using UnityEngine;

public class CabinUhOh : MonoBehaviour
{
    public bool inside = false;
    public bool interacted = false;


    //Object triggers
    public GameObject BedroomEvent5;


    //Audio triggers
    //Must be same as one activated by engine event
    public AudioSource Alarmnoise2;
    public AudioSource ellaIDontKnowHowToFixThis;

    //standard interaction prompt
    public GameObject EInteract;

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
            Ask();

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
    void Ask()
    {
        ellaIDontKnowHowToFixThis.Play();
        BedroomEvent5.SetActive(true);
    }
}
