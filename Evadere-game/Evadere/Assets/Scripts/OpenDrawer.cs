using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    [SerializeField] private Vector3 openPosition, closedPosition;

    [SerializeField] private float animationTime;

    [SerializeField] private bool isOpen = false;

    [SerializeField] private MovementType movementType;

    private enum MovementType { Slide, Rotate };
    private Hashtable iTweenArgs;
    private AudioSource aSource;

    void Start()
    {
        iTweenArgs = iTween.Hash();
        iTweenArgs.Add("position", openPosition);
        iTweenArgs.Add("time", animationTime);
        iTweenArgs.Add("islocal", true);

        aSource = GetComponent<AudioSource>();
    }

    public void PerformAction()
    {
        if (aSource)
        {
            aSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
            {
                iTweenArgs["position"] = closedPosition;
                iTweenArgs["rotation"] = closedPosition;
            }
            else
            {
                iTweenArgs["position"] = openPosition;
                iTweenArgs["rotation"] = openPosition;
            }

            isOpen = !isOpen;

            switch (movementType)
            {
                case MovementType.Slide:
                    iTween.MoveTo(gameObject, iTweenArgs);
                    break;
                case MovementType.Rotate:
                    iTween.RotateTo(gameObject, iTweenArgs);
                    break;
            }
        }
    }
}
