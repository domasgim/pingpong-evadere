using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
	public string interactButton;
	public float interactDistance = 3f;
	public LayerMask interactLayer;
	public Image interactIcon;
	public bool isInteracting;

    // Start is called before the first frame update
    void Start()
	{
		if (interactIcon != null)
			interactIcon.enabled = false;
	}

	//Update is called once per frame

	void Update()
    {
		Ray interactRay = new Ray(transform.position, transform.forward);
		RaycastHit hitInformation;

		if (Physics.Raycast(interactRay, out hitInformation, interactDistance, interactLayer) && isInteracting == false)
		{
			//Debug.Log("A");
			interactIcon.enabled = true;
			if (Input.GetButtonDown(interactButton))
			{
				if (hitInformation.collider.CompareTag("Door"))
					hitInformation.collider.GetComponent<Door>().ChangeDoorState();
				if (hitInformation.collider.CompareTag("Note"))
					hitInformation.collider.GetComponent<Note>().ShowNoteImage();
                if (hitInformation.collider.CompareTag("Chair"))
                    hitInformation.collider.GetComponent<PickUp>();
            }
		}
		else
			interactIcon.enabled = false;
    }
}
