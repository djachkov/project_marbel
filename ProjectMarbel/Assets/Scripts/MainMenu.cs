using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] Canvas mainMenu;
    [SerializeField] Canvas credits;
    [SerializeField] Canvas settingsMain;

    [SerializeField] Canvas settingsSound;
    [SerializeField] Canvas settingsGraphics;

    [SerializeField] Canvas NullScene;

    // Start is called before the first frame update

    public void toCredits()
    {
        mainMenu.GetComponent<Canvas>().enabled = false;
        credits.GetComponent<Canvas>().enabled = true;
    }

    public void fromCredits()
    {
        mainMenu.GetComponent<Canvas>().enabled = true;
        credits.GetComponent<Canvas>().enabled = false;
    }

        public void toSettings()
    {
        mainMenu.GetComponent<Canvas>().enabled = false;
        settingsMain.GetComponent<Canvas>().enabled = true;
    }

    public void fromSettings()
    {
        settingsMain.GetComponent<Canvas>().enabled = false;
        settingsSound.GetComponent<Canvas>().enabled = false;
        settingsGraphics.GetComponent<Canvas>().enabled = false;
        mainMenu.GetComponent<Canvas>().enabled = true;
    }

    public void onSound()
    {
        settingsSound.GetComponent<Canvas>().enabled = true;
        settingsGraphics.GetComponent<Canvas>().enabled = false;
    }

    public void onGraphics()
    {
        settingsSound.GetComponent<Canvas>().enabled = false;
        settingsGraphics.GetComponent<Canvas>().enabled = true;
    }

    public void quitApplication()
    {
        Debug.Log("Quitting game...");

        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    public void toTutorial()
    {
        toScene("MarbleSelectionTest");
    }

        public void toHotseat()
    {
        toScene("NotGonnaBeThereYet");
    }

    public void fromNullScene()
    {
        NullScene.GetComponent<Canvas>().enabled = false;
        mainMenu.GetComponent<Canvas>().enabled = true;      
    }

    private void toScene(string scene)
    {
        scene = "Assets/Scenes/" +  scene + ".unity";
        
        SceneManager.LoadScene(scene,LoadSceneMode.Single);

        if (!SceneManager.GetSceneByPath(scene).IsValid())
        {
            NullScene.GetComponent<Canvas>().enabled = true;
            mainMenu.GetComponent<Canvas>().enabled = false;
            Debug.Log("Scene Not Found!");
        }

    }
}

