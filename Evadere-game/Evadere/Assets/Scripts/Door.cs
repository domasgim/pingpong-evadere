using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour

	
{
	public bool isDoorOpen = false;
	public float doorOpenAngle = 90f;
	public float doorClosedAngle = 0f;
	public float animationSmoothness = 2f;

	public void ChangeDoorState()
	{
		isDoorOpen = !isDoorOpen;
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
