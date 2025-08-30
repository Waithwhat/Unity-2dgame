using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance;
    public AudioMixer audioMixer;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
            return;
        }
    }

    private void Start() {
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume", 0.5f));
        SetSfxVolume(PlayerPrefs.GetFloat("SfxVolume", 0.5f));
    }

    public void SetMusicVolume(float volume) {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSfxVolume(float volume) {
        audioMixer.SetFloat("SfxVolume", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20);
        PlayerPrefs.SetFloat("SfxVolume", volume);
    }
}