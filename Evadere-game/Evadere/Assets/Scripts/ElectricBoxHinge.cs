﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBoxHinge : MonoBehaviour
{
	public bool isHingeOpen = false;
	//public bool isDoorUnlocked = true;
	public float hingeOpenAngle = -100f;
	public float hingeClosedAngle = -20f;
	public float animationSmoothness = 2f;

	public void ChangeHingeState()
	{
		isHingeOpen = !isHingeOpen;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (isHingeOpen)
		{
			Quaternion targetRotationOpen = Quaternion.Euler(transform.GetChild(1).localRotation.x, hingeOpenAngle, transform.GetChild(1).localRotation.z);
			transform.GetChild(1).localRotation = Quaternion.Slerp(transform.GetChild(1).localRotation,
				targetRotationOpen, animationSmoothness * Time.deltaTime);

		}
		else
		{
			Quaternion targetRotationClosed = Quaternion.Euler(transform.GetChild(1).localRotation.x, hingeClosedAngle, transform.GetChild(1).localRotation.z);
			transform.GetChild(1).localRotation = Quaternion.Slerp(transform.GetChild(1).localRotation,
				targetRotationClosed, animationSmoothness * Time.deltaTime);
		}
	}
}
