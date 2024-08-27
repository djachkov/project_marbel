using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]  Material highlightMaterial;
    [SerializeField]  string selectableTag = "Selectable";
    // Start is called before the first frame update

    Transform selected;
    public Transform selected_parent;

    [SerializeField] public Transform player1;
    [SerializeField] public Transform player2;

    [SerializeField] public TMP_Text promptText;

    [SerializeField] public Button playBtn;

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0,0.05f,0);
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
            var selected_obj_parent = hit.transform;
            if(selected_obj_parent.CompareTag(selectableTag))
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
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Selected Marble: " + marbleName);
                    if (player1 == null)
                    {
                        player1 = selected_obj_parent;
                        promptText.text = "Player 2 select";
                    }
                    else
                    {
                        player2 = selected_obj_parent;
                        promptText.text = "PLAY!";
                        playBtn.interactable = true;
                    }
                }
                selected_parent = selected_obj_parent;
                selected = selected_obj;
            }
        }

    }
}
