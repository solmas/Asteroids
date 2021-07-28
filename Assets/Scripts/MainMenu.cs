using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public Button StartButton;
    public Button OptionsButton;
    public Button BackButton;
    public Button QuitButton;
    public List<Button> MainMenuButtons;
    public List<Button> OptionsMenuButtons;

    private void Start()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }



    #region
    // Fix this region later
    // Need to figure out a better way of getting child buttons
    // Or build an event script that gets the button name and fires a specific event for it
    private void GetMainMenuPanel()
    {
        // parent game object
        Transform current = transform.GetChild(0).GetChild(1);
        var buttonParent = current.gameObject;
        GetButtons(buttonParent);
    }

    private void GetOptionsMenuPanel()
    {
        // parent game object
        Transform current = transform.GetChild(1).GetChild(1);
        var buttonParent = current.gameObject;
        GetButtons(buttonParent);
    }

    private void GetButtons(GameObject buttonParent)
    {
        Button[] buttons = buttonParent.GetComponentsInChildren<Button>(true);
        foreach (var button in buttons)
        {
            if (button.name == "StartButton")
            {
                StartButton = button;
                MainMenuButtons.Add(button);
            }
            if (button.name == "OptionsButton")
            {
                OptionsButton = button;
                MainMenuButtons.Add(button);
            }
            if (button.name == "QuitButton")
            {
                QuitButton = button;
                MainMenuButtons.Add(button);
            }
            if (button.name == "BackButton")
            {
                BackButton = button;
                OptionsMenuButtons.Add(button);
            }
        }
    }
    #endregion
}
