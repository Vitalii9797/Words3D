using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public delegate void RewardedAdWatched();
    public event RewardedAdWatched OnRewardedAdWatched;

    [SerializeField] private GameObject adsPopUp;
    [SerializeField] private Animator noadsText;
    [SerializeField] HintButton hintButton;

    private readonly string adUnitID = "RewardedAd";
    private void Start()
    {
        Advertisement.Load(adUnitID, this);
        hintButton.OnHintButtonClicked += OpenAdsPopUp;
    }

    private void OpenAdsPopUp()
    {
        adsPopUp.SetActive(true);
    }

    public void CloseAdsPopUp()
    {
        adsPopUp.SetActive(false);
    }

    public void ShowAd()
    {
        if(Advertisement.isInitialized)
        {
            CloseAdsPopUp();
            Advertisement.Show(adUnitID, this);
        }
        else
        {
            CloseAdsPopUp();
            noadsText.SetTrigger("noads");
        }
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ads Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Ads load failed " + message);
    }


    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (OnRewardedAdWatched != null) OnRewardedAdWatched();
        Advertisement.Load(adUnitID, this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        noadsText.SetTrigger("noads");
    }

    public void OnUnityAdsShowClick(string placementId) { }
    public void OnUnityAdsShowStart(string placementId) { }

    private void OnDisable()
    {
        hintButton.OnHintButtonClicked -= OpenAdsPopUp;
    }

}
