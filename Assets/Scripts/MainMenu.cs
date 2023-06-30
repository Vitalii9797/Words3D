using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MainMenu : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] PlayButton playButton;
    [SerializeField] private string gameId;
    [SerializeField] private string Level;


    void Start()
    {
        StartCoroutine(InitialiseAds());
        playButton.OnPlayButtonPressed += StartGame;
    }

    private void StartGame()
    {
        SceneManager.LoadScene(Level);
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
}
