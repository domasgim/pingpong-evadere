using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetFlashlight : MonoBehaviour
{
    private Vector3 vectOffset;
    private GameObject goFollow;
    [SerializeField] private float speed = 3.0f;

    private void Start()
    {
        goFollow = Camera.main.gameObject;
        vectOffset = transform.position - goFollow.transform.position;

    }

    void Update()
    {
        transform.position = goFollow.transform.position + vectOffset;
        transform.rotation = Quaternion.Slerp(transform.rotation, goFollow.transform.rotation, speed * Time.deltaTime);
    }
}
