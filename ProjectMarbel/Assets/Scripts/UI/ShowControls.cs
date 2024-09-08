using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowControls : MonoBehaviour
{
    [SerializeField]
    private TMP_Text controlsText;
    [SerializeField]
    private float timeLimit = 30f;

    void Start()
    {
        StartCoroutine(HideControlsAfterDelay());
    }

    IEnumerator HideControlsAfterDelay()
    {
        controlsText.enabled = true;
        yield return new WaitForSeconds(timeLimit);
        controlsText.enabled = false;
    }
}