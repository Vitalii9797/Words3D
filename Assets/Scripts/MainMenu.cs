using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MainMenu : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string gameId;
    [SerializeField] private TestLevel testLevel1;
    [SerializeField] private TestLevel testLevel2;

    void Start()
    {
        StartCoroutine(InitialiseAds());
        testLevel1.OnLoadLevelPressed += StartGame;
        testLevel2.OnLoadLevelPressed += StartGame;
    }

    private void StartGame(string level)
    {
        SceneManager.LoadScene(level);
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
