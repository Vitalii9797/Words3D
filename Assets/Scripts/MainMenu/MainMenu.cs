using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MainMenu : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string gameId;
    [SerializeField] private GameObject sunAndClouds;
    [SerializeField] PlayButton playButton;
    [SerializeField] private CameraAnim cameraAnim;
    [SerializeField] private MainTitle title;
    [SerializeField] private Image fadeImage;
    [SerializeField] private Animator fadeAnim;
    [SerializeField] private string levelToLoad;
    [SerializeField] private GameObject popUps;
    [SerializeField] private SimpleButton settingsButton;
    [SerializeField] private SimpleButton exitButton;

    private void Awake()
    {
        cameraAnim.OnCameraAnimationEnded += ActivateMainTitle;
        title.OnAnimationEnded += ActivatePlayButton;
    }
    private void Start()
    {
      //  StartCoroutine(InitialiseAds());
        playButton.OnPlayButtonPressed += StartGame;
        PlayerPrefs.SetInt("House1", 1);

    }

    private void StartGame()
    {
        fadeAnim.SetBool("fade", true);
        StartCoroutine(LoadLevel(levelToLoad));
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Ads successfully initialized!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log(message);
    }

    private IEnumerator InitialiseAds()
    {
        while(!Advertisement.isInitialized)
        {
            Advertisement.Initialize(gameId, false, this);
            yield return new WaitForEndOfFrame();
        }
    }

    private void ActivateMainTitle()
    {
        title.gameObject.SetActive(true);
        sunAndClouds.SetActive(true);
    }

    private void ActivatePlayButton()
    {
        playButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);

        popUps.SetActive(true);
    }

    private IEnumerator LoadLevel(string level)
    {
        while (fadeImage.color.a < 0.99f)
        {
            yield return new WaitForEndOfFrame();
        }

        if (fadeImage.color.a > 0.99f)
        {
            SceneManager.LoadScene(level);
        }
    }

    private void OnDisable()
    {
        cameraAnim.OnCameraAnimationEnded -= ActivateMainTitle;
        title.OnAnimationEnded -= ActivatePlayButton;
    }

    public void TestLevel()
    {
        SceneManager.LoadScene("Motel_1");
    }
}
