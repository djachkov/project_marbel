using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] Material highlightMaterial;
    [SerializeField] string selectableTag = "Selectable";
    // Start is called before the first frame update

    Transform selected;
    public Transform selected_parent;
    private int currentPlayerIndex = 1;

    [SerializeField] public Transform player1;
    [SerializeField] public Transform player2;

    [SerializeField] public TMP_Text promptText;

    [SerializeField] public Button playBtn;
    [SerializeField] SelectionUI selectionUI;

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 0.05f, 0);
        PersistentDataManager.Instance.SetPlayerName(1, "Player 100");
        PersistentDataManager.Instance.SetPlayerName(2, "Player 200");
        SetCurrentPlayer(1);
    }

    // Update is called once per frame
    void Update()
    {

        if (selected != null)
        {
            var selectRend = selected.GetComponent<Renderer>();
            if (selectRend != null)
            {
                selectRend.material = selected.GetComponentInParent<MarbleStats>().defaultMaterial;
                var pos = selected.position;
                selected.position = pos - offset;
                selected_parent = null;
                selected = null;
            }
        }


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            HoverMarbel(hit);
        }

    }
    void HoverMarbel(RaycastHit hit)
    {
        var selected_obj_parent = hit.transform;
        if (selected_obj_parent.CompareTag(selectableTag))
        {
            Transform selected_obj = selected_obj_parent.GetChild(0);
            if (selected == null)
            {
                var pos = selected_obj.position;
                selected_obj.position = pos + offset;

            }
            var selectRend = selected_obj.GetComponent<Renderer>();
            if (selectRend != null)
            {
                selectRend.material = highlightMaterial;
            }

            string marbleName = selected_obj_parent.GetComponent<MarbleStats>().marbleName;
            selectionUI.SetNameText(marbleName);

            SelectMarbel(selected_obj_parent);
            selected_parent = selected_obj_parent;
            selected = selected_obj;

        }
    }
    void SelectMarbel(Transform marble)
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (currentPlayerIndex == 1)
            {
                player1 = marble;
                SetCurrentPlayer(2);
                Debug.Log("Player 1 selected");
            }
            else if (currentPlayerIndex == 2)
            {
                player2 = marble;
                selectionUI.SetPromptText("Ready to PLAY!");
                playBtn.interactable = true;
                Debug.Log("Player 2 selected");

            }
            else
            {
                Debug.LogError("Invalid player index! Use 1 or 2.");
            }
        }
    }
    void SetCurrentPlayer(int playerNumber)
    {
        currentPlayerIndex = playerNumber;
        string playerName = PersistentDataManager.Instance.GetPlayerName(playerNumber);
        Debug.Log("Current Player: " + playerName);

        selectionUI.SetPromptText(playerName);
        selectionUI.SetPlayerName(playerName);

    }
    public void ChangePlayerName()
    {
        string playerName = selectionUI.GetPlayerName();
        PersistentDataManager.Instance.SetPlayerName(currentPlayerIndex, playerName);
        selectionUI.SetPromptText(playerName);
    }
}



// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// public class SelectionManager : MonoBehaviour
// {
//     [SerializeField] Material highlightMaterial;
//     [SerializeField] string selectableTag = "Selectable";
//     // Start is called before the first frame update

//     Transform selected;
//     public Transform selected_parent;

//     [SerializeField] public Transform player1;
//     [SerializeField] public Transform player2;

//     [SerializeField] public TMP_Text promptText;

//     [SerializeField] public Button playBtn;
//     [SerializeField] PlayerNameInput playerNameInputField;

//     private Vector3 offset;

//     void Start()
//     {
//         offset = new Vector3(0, 0.05f, 0);
//         PersistentDataManager.Instance.SetPlayerName(1, "Player 1");
//         PersistentDataManager.Instance.SetPlayerName(2, "Player 2");
//         promptText.text = PersistentDataManager.Instance.GetPlayerName(1) + " select";
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         if (selected != null)
//         {
//             var selectRend = selected.GetComponent<Renderer>();
//             if (selectRend != null)
//             {
//                 selectRend.material = selected.GetComponentInParent<MarbleStats>().defaultMaterial;
//                 var pos = selected.position;
//                 selected.position = pos - offset;
//                 selected_parent = null;
//                 selected = null;
//             }
//         }


//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//         RaycastHit hit;

//         if (Physics.Raycast(ray, out hit, 100f))
//         {
//             var selected_obj_parent = hit.transform;
//             if (selected_obj_parent.CompareTag(selectableTag))
//             {
//                 Transform selected_obj = selected_obj_parent.GetChild(0);
//                 if (selected == null)
//                 {
//                     var pos = selected_obj.position;
//                     selected_obj.position = pos + offset;

//                 }
//                 var selectRend = selected_obj.GetComponent<Renderer>();
//                 if (selectRend != null)
//                 {
//                     selectRend.material = highlightMaterial;
//                 }

//                 string marbleName = selected_obj_parent.GetComponent<MarbleStats>().marbleName;
//                 if (Input.GetMouseButtonDown(0))
//                 {
//                     Debug.Log("Selected Marble: " + marbleName);
//                     if (player1 == null)
//                     {
//                         player1 = selected_obj_parent;
//                         playerNameInputField.SetPlayerIndex(2);
//                         promptText.text = PersistentDataManager.Instance.GetPlayerName(2) + " select";

//                     }
//                     else
//                     {
//                         player2 = selected_obj_parent;
//                         promptText.text = "Ready to PLAY!";
//                         playBtn.interactable = true;
//                     }
//                 }
//                 selected_parent = selected_obj_parent;
//                 selected = selected_obj;
//             }
//         }

//     }
// }
