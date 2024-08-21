using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


namespace Bootup{
    public class Bootup : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private AudioMixer mixer;
        void Start()
        {
            if (!PlayerPrefs.HasKey("Fullscreen"))
            {
                PlayerPrefs.SetInt("Fullscreen",0);
            }

            if (!PlayerPrefs.HasKey("Resoloution"))
            {
                PlayerPrefs.SetInt("Resoloution",0);
            }
            
            newResoloution();

            float masterVol;
            float VFXVol;
            float MusicVol;
            if (PlayerPrefs.HasKey("MasterVolume"))
            {
                masterVol = PlayerPrefs.GetFloat("MasterVolume");
                
            }
            else
            {
                masterVol = 0.5f;
            }

            if (PlayerPrefs.HasKey("VFXrVolume"))
            {
                VFXVol = PlayerPrefs.GetFloat("VFXrVolume");
            }

            else
            {
                VFXVol = 0.5f;
            }

            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                MusicVol = PlayerPrefs.GetFloat("MusicVolume");
            }

            else
            {
                MusicVol = 0.5f;
            }

            setMasterVolume(masterVol);
            setVFXVolume(VFXVol);
            setMuiscVolume(MusicVol);

            SceneManager.LoadScene("Assets/Scenes/MainMenu.unity",LoadSceneMode.Single);
        }

        private void newResoloution()
        {

            bool fullscreen;
            if (PlayerPrefs.GetInt("Fullscreen") != 0)
            {
                fullscreen = true;
            }
            else
            {
                fullscreen = false;
            }

            Screen.SetResolution(
                PlayerPrefs.GetInt("Width"),
                PlayerPrefs.GetInt("Height"),
                fullscreen);
        }

        private void setMasterVolume(float masterVol)
        {
            float masterVolume = Mathf.Log10(masterVol) * 20;
            mixer.SetFloat("Master",masterVolume);
            PlayerPrefs.SetFloat("MasterVolume", masterVol);
        }

        private void setVFXVolume(float VFXVol)
        {
            float vfxVolume = Mathf.Log10(VFXVol) * 20;
            mixer.SetFloat("VFX",vfxVolume);
            PlayerPrefs.SetFloat("VFXrVolume", VFXVol);
        }

        private void setMuiscVolume(float MusicVol)
        {
            float musicVolume = Mathf.Log10(MusicVol) * 20;
            mixer.SetFloat("Music",musicVolume);
            PlayerPrefs.SetFloat("MusicVolume", MusicVol);
        }

    }
}
