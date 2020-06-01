using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject newGameButton;
    public GameObject playButton;

    private void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            newGameButton.SetActive(true);
            continueButton.SetActive(true);
            playButton.SetActive(false);
        }
        else
        {
            newGameButton.SetActive(false);
            continueButton.SetActive(false);
            playButton.SetActive(true);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveSystem.RemoveSave();
	}

    public void ContinueGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if(data != null)
        {
            SceneManager.LoadScene(data.level);
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            PauseMenu.PlayerTransform(position, true);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

