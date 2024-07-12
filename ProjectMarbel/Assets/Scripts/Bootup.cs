using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bootup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {        
        SceneManager.LoadScene("Assets/Scenes/MainMenu.unity",LoadSceneMode.Single);
    }

}
