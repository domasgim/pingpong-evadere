using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    private AudioSource audioSource;
    public AudioClip openingSound;
    public bool isDoorOpen = false;
    public float doorOpenAngle = 90f;
    public float doorClosedAngle = 0f;
    public float animationSmoothness = 2f;

    void OnTriggerEnter (Collider col)
    {
        door.transform.position += new Vector3(0, 5, 0);
        //add sound effect
    }

    void OnTriggerExit(Collider col)
    {
        door.transform.position += new Vector3(0, -5, 0);
    }
}
