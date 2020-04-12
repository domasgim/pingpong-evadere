using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class NoteCode : MonoBehaviour
{
    public Image noteImage;
    public GameObject hideNoteButton;
    public AudioClip pickupSound;
    public AudioClip putAwaySound;
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        noteImage.enabled = false;
        hideNoteButton.SetActive(false);
    }

    public void ShowNoteImage()
    {
        noteImage.enabled = true;
        GetComponent<AudioSource>().PlayOneShot(pickupSound);

        //Lock player movement when the note is opened
        playerObject.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        hideNoteButton.SetActive(true);
    }
    public void HideNoteImage()
    {
        noteImage.enabled = false;
        GetComponent<AudioSource>().PlayOneShot(putAwaySound);

        //Unlock player movement when the note is closed
        playerObject.GetComponent<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        hideNoteButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
