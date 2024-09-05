using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private AudioMixer mixer;

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider vfxSlider;
    [SerializeField] private Slider musicSlider;

    public float masterVolume = 1.0f;

    public float vfxVolume = 1.0f;
    public float musicVolume = 1.0f;

    void Start()
    {

        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            
        }
        else
        {
            masterSlider.value = 0.5f;
        }

        if (PlayerPrefs.HasKey("VFXrVolume"))
        {
            vfxSlider.value = PlayerPrefs.GetFloat("VFXrVolume");
        }

        else
        {
            vfxSlider.value = 0.5f;
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        else
        {
            musicSlider.value = 0.5f;
        }

        setMasterVolume();
        setVFXVolume();
        setMuiscVolume();
    }

    public void reset()
    {
        masterSlider.value = 0.5f;
        vfxSlider.value = 0.5f;
        musicSlider.value = 0.5f;

        setMasterVolume();
        setVFXVolume();
        setMuiscVolume();
    }

    public void setMasterVolume()
    {
        masterVolume = Mathf.Log10(masterSlider.value) * 20;
        mixer.SetFloat("Master",masterVolume);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }

    public void setVFXVolume()
    {
        vfxVolume = Mathf.Log10(vfxSlider.value) * 20;
        mixer.SetFloat("VFX",vfxVolume);
        PlayerPrefs.SetFloat("VFXrVolume", vfxSlider.value);
    }

    public void setMuiscVolume()
    {
        musicVolume = Mathf.Log10(musicSlider.value) * 20;
        mixer.SetFloat("Music",musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
}
