using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeValve : MonoBehaviour
{
	public bool isValveOpen = false;
	//public bool isDoorUnlocked = true;
	public float valveOpenAngle = 0f;
	public float valveClosedAngle = 90f;
	public float animationSmoothness = 2f;

	public void ChangeValveState()
	{
		isValveOpen = !isValveOpen;
	}

	// Start is called before the first frame update
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if (isValveOpen)
		{
			Quaternion targetRotationOpen = Quaternion.Euler(valveOpenAngle, transform.GetChild(0).localRotation.y, transform.GetChild(0).localRotation.z);
			transform.GetChild(0).localRotation = Quaternion.Slerp(transform.GetChild(0).localRotation,
				targetRotationOpen, animationSmoothness * Time.deltaTime);

		}
		else
		{
			Quaternion targetRotationClosed = Quaternion.Euler(valveClosedAngle, transform.GetChild(0).localRotation.y, transform.GetChild(0).localRotation.z);
			transform.GetChild(0).localRotation = Quaternion.Slerp(transform.GetChild(0).localRotation,
				targetRotationClosed, animationSmoothness * Time.deltaTime);
		}
	}
}
