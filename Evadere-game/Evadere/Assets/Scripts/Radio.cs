using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip numberMorseCode;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayNumberCode()
    {
        Debug.Log("Radio morse code sound");

        if (audioSource != null)
            audioSource.PlayOneShot(numberMorseCode);
    }
}
