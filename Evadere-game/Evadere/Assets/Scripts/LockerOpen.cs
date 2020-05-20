using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerOpen : MonoBehaviour


{
    public bool isDoorOpen = false;
    public bool isDoorUnlocked = true;
    public float doorOpenAngle = 90f;
    public float doorClosedAngle = 0f;
    public float animationSmoothness = 2f;

    private AudioSource audioSource;
    public AudioClip openingSound;

    public void ChangeDoorState()
    {
        if (isDoorUnlocked)
        {
            isDoorOpen = !isDoorOpen;

            if (audioSource != null)
                audioSource.PlayOneShot(openingSound);
        }
        else
        {
            bool hasAKey = false;
            // Call function to check if the inventory holds a key
            //hasAKey = Inventory.instance.inInventory("Key1");
            if (hasAKey)
            {
                isDoorUnlocked = !isDoorUnlocked;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoorUnlocked)
        {
            if (isDoorOpen)
            {
                Quaternion targetRotationOpen = Quaternion.Euler(-0, doorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation,
                    targetRotationOpen, animationSmoothness * Time.deltaTime);

            }
            else
            {
                Quaternion targetRotationClosed = Quaternion.Euler(-0, doorClosedAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation,
                    targetRotationClosed, animationSmoothness * Time.deltaTime);
            }
        }
    }
}
