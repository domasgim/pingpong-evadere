using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class LockerCode : MonoBehaviour
{
    public Canvas safeCanvas;
    public GameObject playerObject;
    public GameObject hideCodeButton;
    public GameObject openDoorButton;
    public GameObject planeCollider;
    public float doorOpenAngle = 90f;
    public float animationSmoothness = 2f;

    private AudioSource audioSource;
    public AudioClip openingSound;
    public AudioClip closingSound;
    public AudioClip clickSound;


    private int number01 = 1;
    private int number02 = 1;
    private int number03 = 1;
    private int number04 = 1;

    public Text textNumber01;
    public Text textNumber02;
    public Text textNumber03;
    public Text textNumber04;

    public int one;
    public int two;
    public int three;
    public int four;

    public bool opened;

    public bool isTransitionDoor;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        opened = false;
        safeCanvas.enabled = false;
        hideCodeButton.SetActive(false);
        openDoorButton.SetActive(false);
    }

    public void ShowCodeCanvas()
    {

        safeCanvas.enabled = true;
        playerObject.GetComponent<FirstPersonController>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        hideCodeButton.SetActive(true);
        openDoorButton.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (opened == true)
        {
            Open();
            planeCollider.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    public void Open()
    {
        Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation,
            targetRotationOpen, animationSmoothness * Time.deltaTime);
    }

    public void UnlockDoor()
    {
        if (number01 == one && number02 == two && number03 == three && number04 == four)
        {
            Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation,
                targetRotationOpen, animationSmoothness * Time.deltaTime);

            if (audioSource != null)
                audioSource.PlayOneShot(openingSound);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerObject.GetComponent<FirstPersonController>().enabled = true;
            safeCanvas.enabled = false;
            hideCodeButton.SetActive(false);

            opened = true;

            if (isTransitionDoor)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            if (audioSource != null)
                audioSource.PlayOneShot(closingSound);
        }
    }


    public void ExitCanvas(int _number)
    {
        if (_number == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerObject.GetComponent<FirstPersonController>().enabled = true;
            safeCanvas.enabled = false;
            hideCodeButton.SetActive(false);

        }
    }

    public void IncreaseNumber(int _number)
    {
        if (audioSource != null)
            audioSource.PlayOneShot(clickSound);
        if (_number == 1)
        {
            number01++;
            textNumber01.text = number01.ToString();
            if (number01 > 9)
            {
                number01 = 1;
                textNumber01.text = number01.ToString();
            }
        }

        else if (_number == 2)
        {
            number02++;
            textNumber02.text = number02.ToString();
            if (number02 > 9)
            {
                number02 = 1;
                textNumber02.text = number02.ToString();
            }
        }

        else if (_number == 3)
        {
            number03++;
            textNumber03.text = number03.ToString();
            if (number03 > 9)
            {
                number03 = 1;
                textNumber03.text = number03.ToString();
            }
        }

        else if (_number == 4)
        {
            number04++;
            textNumber04.text = number04.ToString();
            if (number04 > 9)
            {
                number04 = 1;
                textNumber04.text = number04.ToString();
            }
        }
    }

    public void DecreaseNumber(int _number)
    {
        if (audioSource != null)
            audioSource.PlayOneShot(clickSound);

        if (_number == 1)
        {
            number01--;
            textNumber01.text = number01.ToString();
            if (number01 < 1)
            {
                number01 = 9;
                textNumber01.text = number01.ToString();
            }
        }

        else if (_number == 2)
        {
            number02--;
            textNumber02.text = number02.ToString();
            if (number02 < 1)
            {
                number02 = 9;
                textNumber02.text = number02.ToString();
            }
        }

        else if (_number == 3)
        {
            number03--;
            textNumber03.text = number03.ToString();
            if (number03 < 1)
            {
                number03 = 9;
                textNumber03.text = number03.ToString();
            }
        }

        else if (_number == 4)
        {
            number04--;
            textNumber04.text = number04.ToString();
            if (number04 < 1)
            {
                number04 = 9;
                textNumber04.text = number04.ToString();
            }
        }
    }
}
