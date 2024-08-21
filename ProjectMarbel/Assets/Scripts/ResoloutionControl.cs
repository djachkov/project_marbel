using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace ResoloutionControl{
    public class ResoloutionControl : MonoBehaviour
    {
        [SerializeField] TMP_Dropdown resoloution;
        [SerializeField] TMP_Text fullscreenBtn;
        // Start is called before the first frame update
        void Start()
        {
            if (PlayerPrefs.HasKey("Resoloution"))
            {
                resoloution.value = PlayerPrefs.GetInt("Resoloution");
            }

            checkFullscreen();
        }

        public void newResoloution()
        {
            Debug.Log(resoloution.value);


            switch (resoloution.value)
            {
                case 0:
                    PlayerPrefs.SetInt("Resoloution",0);
                    PlayerPrefs.SetInt("Width",1280);
                    PlayerPrefs.SetInt("Height",720);
                    break;

                case 1:
                    PlayerPrefs.SetInt("Resoloution",1);
                    PlayerPrefs.SetInt("Width",1600);
                    PlayerPrefs.SetInt("Height",900);
                    break;

                case 2:
                    PlayerPrefs.SetInt("Resoloution",2);
                    PlayerPrefs.SetInt("Width",1920);
                    PlayerPrefs.SetInt("Height",1080);
                    break;

                case 3:
                    PlayerPrefs.SetInt("Resoloution",3);
                    PlayerPrefs.SetInt("Width",2560);
                    PlayerPrefs.SetInt("Height",1440);
                    break;

            }

            Screen.SetResolution(
                PlayerPrefs.GetInt("Width"),
                PlayerPrefs.GetInt("Height"),
                checkFullscreen());
        }

        public void toggleFullscreen()
        {
            if(checkFullscreen())
            {
                PlayerPrefs.SetInt("Fullscreen",0);
            }
            else
            {
                PlayerPrefs.SetInt("Fullscreen",1);
            }
            newResoloution();
        }

        private bool checkFullscreen()
        {
            bool fullscreen;
            if (PlayerPrefs.GetInt("Fullscreen") != 0)
            {
                fullscreenBtn.text = "X";
                fullscreen = true;
            }
            else
            {
                fullscreenBtn.text = "";
                fullscreen = false;
            }
            return fullscreen;
        }

    }
}
