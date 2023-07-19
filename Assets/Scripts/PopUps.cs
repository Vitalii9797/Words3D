using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUps : MonoBehaviour
{
    [Header("Pop Ups")]
    [SerializeField] private GameObject likePopUp;
    [SerializeField] private GameObject ratePopUp;
    [SerializeField] private GameObject aboutPopUp;
    [SerializeField] private GameObject settingsPopUp;
    [SerializeField] private GameObject exitPopUp;
    [SerializeField] private GameObject resetPopUp;
    [Space]
    [Header("Buttons")]
    [SerializeField] private NextButton noLikeButton;
    [SerializeField] private NextButton yesLikeButton;
    [SerializeField] private NextButton noRateButton;
    [SerializeField] private NextButton yesRateButton;
    [SerializeField] private NextButton closeAboutButton;
    [SerializeField] private NextButton aboutButton;
    [SerializeField] private NextButton noResetButton;
    [SerializeField] private NextButton yesResetButton;
    [SerializeField] private NextButton noExitButton;
    [SerializeField] private NextButton yesExitButton;
    [SerializeField] private NextButton closeSettingsButton;
    [SerializeField] private NextButton resetButton;
    [SerializeField] private NextButton moreGamesButton;

    [SerializeField] private SimpleButton exitButton;
    [SerializeField] private SimpleButton settingsButton;

    private int launches;
    private int rated;
    private void Awake()
    {
        launches = PlayerPrefs.GetInt("launches");
        rated = PlayerPrefs.GetInt("rated");

        noLikeButton.OnNextButtonClicked += CloseAllPopUps;
        noRateButton.OnNextButtonClicked += CloseAllPopUps;
        closeAboutButton.OnNextButtonClicked += CloseAllPopUps;
        noResetButton.OnNextButtonClicked += CloseAllPopUps;
        noExitButton.OnNextButtonClicked += CloseAllPopUps;
        closeSettingsButton.OnNextButtonClicked += CloseAllPopUps;

        yesLikeButton.OnNextButtonClicked += YesLikeButton;
        yesRateButton.OnNextButtonClicked += YesRateButton;
        aboutButton.OnNextButtonClicked += AboutButton;
        yesResetButton.OnNextButtonClicked += ResetProgress;
        yesExitButton.OnNextButtonClicked += ExitGame;
        moreGamesButton.OnNextButtonClicked += MoreGames;
        resetButton.OnNextButtonClicked += ResetButton;

        settingsButton.OnButtonPressed += SettingsButton;
        exitButton.OnButtonPressed += ExitButton;
    }

    private void Start()
    {
        launches++;
        PlayerPrefs.SetInt("launches", launches);
    }
    private void OnEnable()
    {
        if(launches != 0)
        {
            if (launches % 2 == 0 && rated != 1)
            {
                likePopUp.SetActive(true);
            }
        }
    }

    private void CloseAllPopUps()
    {
        likePopUp.SetActive(false);
        ratePopUp.SetActive(false);
        resetPopUp.SetActive(false);
        exitPopUp.SetActive(false);
        settingsPopUp.SetActive(false);
        aboutPopUp.SetActive(false);
    }

    private void YesLikeButton()
    {
        CloseAllPopUps();
        ratePopUp.SetActive(true);
    }

    private void YesRateButton()
    {
        CloseAllPopUps();
        PlayerPrefs.SetInt("rated", 1);
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.CokkStar.WordBuilder");
    }

    private void AboutButton()
    {
        CloseAllPopUps();
        aboutPopUp.SetActive(true);
    }

    private void ResetProgress()
    {
        CloseAllPopUps();
        PlayerPrefs.DeleteAll();
        if(rated == 1)
        {
            PlayerPrefs.SetInt("rated", 1);
        }
        SceneManager.LoadScene(0);
    }

    private void ResetButton()
    {
        CloseAllPopUps();
        resetPopUp.SetActive(true);
    }

    private void ExitButton()
    {
        CloseAllPopUps();
        exitPopUp.SetActive(true);
    }

    private void SettingsButton()
    {
        CloseAllPopUps();
        settingsPopUp.SetActive(true);
    }

    private void MoreGames()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=7273818406239829304");
    }

    private void ExitGame()
    {
        Application.Quit();
    }


    private void OnDisable()
    {
        noLikeButton.OnNextButtonClicked -= CloseAllPopUps;
        noRateButton.OnNextButtonClicked -= CloseAllPopUps;
        closeAboutButton.OnNextButtonClicked -= CloseAllPopUps;
        noResetButton.OnNextButtonClicked -= CloseAllPopUps;
        noExitButton.OnNextButtonClicked -= CloseAllPopUps;
        closeSettingsButton.OnNextButtonClicked -= CloseAllPopUps;

        yesLikeButton.OnNextButtonClicked -= YesLikeButton;
        yesRateButton.OnNextButtonClicked -= YesRateButton;
        aboutButton.OnNextButtonClicked -= AboutButton;
        yesResetButton.OnNextButtonClicked -= ResetProgress;
        yesExitButton.OnNextButtonClicked -= ExitGame;
        moreGamesButton.OnNextButtonClicked -= MoreGames;
        resetButton.OnNextButtonClicked -= ResetButton;

        settingsButton.OnButtonPressed -= SettingsButton;
        exitButton.OnButtonPressed -= ExitButton;
    }
}
