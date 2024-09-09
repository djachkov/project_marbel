using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip[] musicClips;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusicForCurrentScene();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForCurrentScene();
    }
    public void PlayMusicForCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int sceneIndex = currentScene.buildIndex;
        if (sceneIndex < musicClips.Length && musicClips[sceneIndex] != null)
        {

            musicSource.clip = musicClips[sceneIndex];
            musicSource.Play();
            Debug.Log("Playeing music: " + musicSource.clip.name);

        }
        else
        {
            Debug.LogWarning("No music assigned for this scene.");
        }
    }

    public void PlaySFX()
    {

        sfxSource.PlayOneShot(musicClips[0]);
        Debug.Log("Playing destruction");

    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}