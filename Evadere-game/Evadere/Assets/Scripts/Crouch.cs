using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
	public GameObject playerScale;
	public Camera myCam;
	public float camHeight = 1f;

    private CharacterController m_CharacterController;
    private bool m_Crouch = false;

    public KeyCode crouchKey = KeyCode.C;

    private float m_OriginalHeight;
    [SerializeField] private float m_CrouchHeight = 0.4f;

    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_OriginalHeight = m_CharacterController.height;
    }

    void Update ()
    {
        if (Input.GetKeyDown(crouchKey)){
            m_Crouch = !m_Crouch;

            CheckCrouch();
        }
    }

    void CheckCrouch()
    {
        if(m_Crouch == true)
        {
			playerScale.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
			//myCam.transform.position = myCam.transform.position - new Vector3(myCam.transform.localPosition.x, camHeight, myCam.transform.localPosition.z);
            m_CharacterController.height = 0;
        }
        else
        {
			playerScale.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
			//myCam.transform.position = myCam.transform.position + new Vector3(myCam.transform.localPosition.x, camHeight, myCam.transform.localPosition.z);
			m_CharacterController.height = m_OriginalHeight;
        }
    }
}
