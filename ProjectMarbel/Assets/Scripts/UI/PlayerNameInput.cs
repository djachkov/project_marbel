using TMPro;
using UnityEngine;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInputField;
    void Start()
    {
        // Optionally set a default value
        playerNameInputField.onEndEdit.AddListener(OnEndEdit);
    }

    public void OnEndEdit(string inputText)
    {
        Debug.Log("Player Name: " + inputText);

        // You can now use this player name as needed, for example, setting it in the PersistentDataManager
    }

    public void SetPlayerName(string name)
    {
        playerNameInputField.text = name;
    }
    public string GetPlayerName()
    {
        return playerNameInputField.text;
    }
    // Clean up listeners when the object is destroyed
    private void OnDestroy()
    {
        playerNameInputField.onEndEdit.RemoveListener(OnEndEdit);
    }
}