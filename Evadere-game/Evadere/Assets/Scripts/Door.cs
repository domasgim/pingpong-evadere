using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour

	
{
    public InventoryObject inventory;

    public bool isDoorOpen = false;
	public bool isDoorUnlocked = true;
	public float doorOpenAngle = 90f;
	public float doorClosedAngle = 0f;
	public float animationSmoothness = 2f;

	private AudioSource audioSource;
	public AudioClip openingSound;
	public AudioClip lockedSound;

	public void ChangeDoorState()
	{
		if (isDoorUnlocked)
		{
			isDoorOpen = !isDoorOpen;

			if (audioSource != null)
			{
				if (!audioSource.isPlaying)
				{
					audioSource.PlayOneShot(openingSound);
				}
			}
		}
		else
		{
			bool hasAKey = false;
            // Call function to check if the inventory holds a key
            for (int i = 0; i < inventory.Container.Items.Length; i++)
            {
                if (inventory.Container.Items[i].item.Name.Contains("Key"))
                {
                    hasAKey = true;
                    inventory.Container.Items[i].ID = -1;
                }
                    
            }
            if (hasAKey)
			{
				isDoorUnlocked = !isDoorUnlocked;
			}
			else audioSource.PlayOneShot(lockedSound);
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
				Quaternion targetRotationOpen = Quaternion.Euler(-90, doorOpenAngle, 0);
				transform.localRotation = Quaternion.Slerp(transform.localRotation,
					targetRotationOpen, animationSmoothness * Time.deltaTime);

			}
			else
			{
				Quaternion targetRotationClosed = Quaternion.Euler(-90, doorClosedAngle, 0);
				transform.localRotation = Quaternion.Slerp(transform.localRotation,
					targetRotationClosed, animationSmoothness * Time.deltaTime);
			}
		}
    }
}
