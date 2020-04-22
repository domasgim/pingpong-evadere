using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
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
            m_CharacterController.height = m_CrouchHeight;
        }
        else
        {
            m_CharacterController.height = m_OriginalHeight;
        }
    }
}
