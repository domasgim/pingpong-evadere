using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCanvas : MonoBehaviour
{
    public GameObject NoteImage;
    public GameObject Button;
    public void CloseCnv()
    {
        NoteImage.SetActive(false);
        Button.SetActive(false);
    }


}
