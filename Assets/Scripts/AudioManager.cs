using UnityEngine;
public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public AudioSource musicAudioSource;
    public AudioSource clickAudioSource;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioManager>();
            }
            return _instance;
        }
    }

    void Start()
    {
        clickAudioSource.volume = PlayerPrefs.GetFloat("sfx");
        musicAudioSource.volume = PlayerPrefs.GetFloat("music");
    }

    public void playClick(){
        clickAudioSource.Play();
    }

    public void playMusic(){
        musicAudioSource.Play();
    }

    public void pauseMusic(){
        musicAudioSource.Pause();
    }

}