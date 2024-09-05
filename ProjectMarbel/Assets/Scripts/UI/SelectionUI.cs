using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Dynamic;

public class SelectionUI : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject marbles;
    [SerializeField] GameObject selected;
    private TMP_Text name_text;
    [SerializeField] public TMP_Text promptText;

    [SerializeField] public Button playBtn;


    [SerializeField] GameObject NameUI;
    [SerializeField] PlayerNameInput playerNameInputField;
    [SerializeField] GameObject SizeBar;
    [SerializeField] GameObject MassBar;

    [SerializeField] Canvas NullScene;
    [SerializeField] Canvas MainScene;

    private float bar_length;
    void Start()
    {
        name_text = NameUI.GetComponent<TMP_Text>();
        marbles = GameObject.Find("Marbles");
        RectTransform barSize = SizeBar.GetComponent<RectTransform>();
        bar_length = barSize.sizeDelta.x;
        SetNameText("SELECT A MARBLE");
    }

    // Update is called once per frame
    void Update()
    {

        if (marbles.GetComponent<SelectionManager>().selected_parent != null)
        {
            selected = marbles.GetComponent<SelectionManager>().selected_parent.gameObject;

            string marbleName = selected.GetComponent<MarbleStats>().marbleName;

            float scale = selected.GetComponent<MarbleStats>().scale;
            float mass = selected.GetComponent<MarbleStats>().mass;
            scale = remap(scale, 0.75f, 1.25f, 0.0f, 1.0f);
            mass = remap(mass, 0.75f, 1.25f, 0.0f, 1.0f);
            RectTransform barSize = SizeBar.GetComponent<RectTransform>();
            barSize.sizeDelta = new Vector2((bar_length * scale), barSize.sizeDelta.y);

            RectTransform barMass = MassBar.GetComponent<RectTransform>();
            barMass.sizeDelta = new Vector2((bar_length * mass), barMass.sizeDelta.y);


        }
        else
        {
            SetNameText("SELECT A MARBLE");

            RectTransform barSize = SizeBar.GetComponent<RectTransform>();
            barSize.sizeDelta = new Vector2(bar_length, barSize.sizeDelta.y);
            RectTransform barMass = MassBar.GetComponent<RectTransform>();
            barMass.sizeDelta = new Vector2(bar_length, barMass.sizeDelta.y);
        }

    }

    public void SetPromptText(string text)
    {
        promptText.text = text;
    }

    public void SetNameText(string text)
    {
        name_text.text = text;
    }
    public void SetPlayerName(string playerName)
    {
        playerNameInputField.SetPlayerName(playerName);
    }
    public string GetPlayerName()
    {
        return playerNameInputField.GetPlayerName();
    }
    public void back()
    {
        if (marbles.GetComponent<SelectionManager>().player1 != null)
        {
            if (marbles.GetComponent<SelectionManager>().player2 != null)
            {
                marbles.GetComponent<SelectionManager>().player2 = null;

                promptText.text = PersistentDataManager.Instance.GetPlayerName(2) + " select";
                playBtn.interactable = false;
            }
            else
            {
                marbles.GetComponent<SelectionManager>().player1 = null;
                promptText.text = PersistentDataManager.Instance.GetPlayerName(1) + " select";
            }
        }
        else
        {
            toScene("MainMenu");
        }
    }

    public void go()
    {
        toScene("CombinedLevels");
    }

    public void fromNullScene()
    {
        NullScene.GetComponent<Canvas>().enabled = false;
        MainScene.GetComponent<Canvas>().enabled = true;
    }

    private void toScene(string scene)
    {
        scene = "Assets/Scenes/" + scene + ".unity";

        SceneManager.LoadScene(scene, LoadSceneMode.Single);

        if (!SceneManager.GetSceneByPath(scene).IsValid())
        {
            NullScene.GetComponent<Canvas>().enabled = true;
            MainScene.GetComponent<Canvas>().enabled = false;
            Debug.Log("Scene Not Found!");
        }

    }

    private float remap(float source, float sourceFrom, float sourceTo, float targetFrom, float targetTo)
    {
        return targetFrom + (source - sourceFrom) * (targetTo - targetFrom) / (sourceTo - sourceFrom);
    }
}
