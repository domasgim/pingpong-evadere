using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject playerObject;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public static void PlayerTransform(Vector3 position, bool afterSave)
    {
        if(afterSave){
            // TODO - add player object position transform       
            Debug.Log(position);
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        playerObject.GetComponent<FirstPersonController>().enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        playerObject.GetComponent<FirstPersonController>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveGame()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        float datax = playerObject.GetComponent<FirstPersonController>().transform.position.x;
        float datay = playerObject.GetComponent<FirstPersonController>().transform.position.y;
        float dataz = playerObject.GetComponent<FirstPersonController>().transform.position.z;
        float[] data = {datax, datay, dataz};
        PlayerData playerData = new PlayerData(level, data);
        SaveSystem.SavePlayer(playerData);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
