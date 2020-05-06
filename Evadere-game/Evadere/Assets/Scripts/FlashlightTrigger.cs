using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightTrigger : MonoBehaviour
{
    public GameObject flashlight;
    bool fEnabled = false;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fEnabled = !fEnabled;
        }

        if (fEnabled)
            flashlight.SetActive(true);
        else
            flashlight.SetActive(false);
    }
}
