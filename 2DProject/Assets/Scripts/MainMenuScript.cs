using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject mainMenuPanel;

    [SerializeField] private Image fadeImage;
    [SerializeField] private CanvasGroup quoteGroup;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float quoteDisplayTime = 3f;

    [SerializeField] private string gameSceneName = "MainScene";

    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start() {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 0.5f);

        musicSlider.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSfxVolume);
    }

    public void PlayGame() {
        StartCoroutine(PlaySequence());
    }

    public void OpenSettings() {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings() {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ExitGame() {
        Application.Quit();
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private IEnumerator PlaySequence() {
        yield return StartCoroutine(Fade(0f, 1f, fadeDuration));
        mainMenuPanel.SetActive(false);
        quoteGroup.gameObject.SetActive(true);
        yield return StartCoroutine(FadeCanvasGroup(quoteGroup, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(quoteDisplayTime);
        yield return StartCoroutine(FadeCanvasGroup(quoteGroup, 1f, 0f, fadeDuration));
        yield return StartCoroutine(Fade(0f, 1f, fadeDuration));
        SceneManager.LoadScene(gameSceneName);
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration) {
        float t = 0f;
        Color c = fadeImage.color;
        while (t < duration) {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(startAlpha, endAlpha, t / duration);
            fadeImage.color = c;
            yield return null;
        }
        c.a = endAlpha;
        fadeImage.color = c;
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float startAlpha, float endAlpha, float duration) {
        float t = 0f;
        while (t < duration) {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(startAlpha, endAlpha, t / duration);
            yield return null;
        }
        cg.alpha = endAlpha;
    }
}