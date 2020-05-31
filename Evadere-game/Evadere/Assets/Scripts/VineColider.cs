using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineColider : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "VineChair")
        {
            door.transform.position += new Vector3(0, -5, 0);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "VineChair")
        {
            door.transform.position += new Vector3(0, 5, 0);
        }
    }
}
