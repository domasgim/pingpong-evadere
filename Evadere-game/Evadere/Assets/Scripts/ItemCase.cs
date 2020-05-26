using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCase : MonoBehaviour
{
	public bool isCaseOpen = false;
	//public bool isDoorUnlocked = true;
	public float caseOpenAngle = 60f;
	public float caseClosedAngle = 0f;
	public float animationSmoothness = 2f;


	public void ChangeCaseState()
	{
		isCaseOpen = !isCaseOpen;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (isCaseOpen)
		{
			Quaternion targetRotationOpen = Quaternion.Euler(caseOpenAngle, transform.GetChild(2).localRotation.y, transform.GetChild(2).localRotation.z);
			transform.GetChild(2).localRotation = Quaternion.Slerp(transform.GetChild(2).localRotation,
				targetRotationOpen, animationSmoothness * Time.deltaTime);

		}
		else
		{
			Quaternion targetRotationClosed = Quaternion.Euler(caseClosedAngle, transform.GetChild(2).localRotation.y, transform.GetChild(2).localRotation.z);
			transform.GetChild(2).localRotation = Quaternion.Slerp(transform.GetChild(2).localRotation,
				targetRotationClosed, animationSmoothness * Time.deltaTime);
		}
	}
}
