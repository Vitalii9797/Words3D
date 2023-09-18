using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI houseNameText;
    [SerializeField] private SelectButton leftButton;
    [SerializeField] private SelectButton rightButton;
    [SerializeField] private HomeButton homeButton;
    [SerializeField] private PlayButton playButton;
    [SerializeField] private PlayButton lockedPlayButton;
    [SerializeField] private Image fadeImage;
    [SerializeField] private Animator fadeAnim;

 
    [Space]
    [Header("Levels")]
    [SerializeField] private Level level1;
    [SerializeField] private Level level2;
    [SerializeField] private Level level3;
    [SerializeField] private Level level4;
    [SerializeField] private Level level5;
    [SerializeField] private Level level6;

    private string currentLevel;
    private string currentLevelName;


    private void Awake()
    {
        level1.OnLevelChange += ChangeLevel;
        level2.OnLevelChange += ChangeLevel;
        level3.OnLevelChange += ChangeLevel;
        level4.OnLevelChange += ChangeLevel;
        level5.OnLevelChange += ChangeLevel;
        level6.OnLevelChange += ChangeLevel;
        level1.OnHouseDeactivated += ActivateNextHouse;
        level2.OnHouseDeactivated += ActivateNextHouse;
        level3.OnHouseDeactivated += ActivateNextHouse;
        level4.OnHouseDeactivated += ActivateNextHouse;
        level5.OnHouseDeactivated += ActivateNextHouse;
        level6.OnHouseDeactivated += ActivateNextHouse;
        leftButton.OnButtonPressed += LeftButton;
        rightButton.OnButtonPressed += RightButton;
        playButton.OnPlayButtonPressed += StartGame;
        homeButton.OnHomePressed += Home;
        lockedPlayButton.OnPlayButtonPressed += LockedButton;
    }

    private void Start()
    {
        level1.gameObject.SetActive(true);
        currentLevel = GetCurrentLevelName();
    }

    private string GetCurrentLevelName()
    {
        if(PlayerPrefs.GetString("CurrentLevel") == string.Empty)
        {
            return "House1_1";
        }
        else
        {
            return PlayerPrefs.GetString("CurrentLevel");
        }
    }

    private void ChangeLevel(string levelName, bool complete)
    {
        currentLevelName = levelName;
        houseNameText.text = levelName;
        int levelUnlocked = PlayerPrefs.GetInt(levelName);
        SetLevelButtons();

        if (complete == true)
        {
            playButton.gameObject.SetActive(false);
            lockedPlayButton.gameObject.SetActive(false);
            return;
        }

            if(levelUnlocked == 1)
            {
                lockedPlayButton.gameObject.SetActive(false);
                playButton.gameObject.SetActive(true);
            }

       
        else
        {
            lockedPlayButton.gameObject.SetActive(true);
            playButton.gameObject.SetActive(false);
           
        }
    }

    private void SetLevelButtons()
    {
        switch(currentLevelName)
        {
            case "House1":
                rightButton.gameObject.SetActive(true);
                rightButton.buttonPressed = false;
                leftButton.buttonPressed = false;
                leftButton.gameObject.SetActive(false);
                break;
            case "House2":
                rightButton.gameObject.SetActive(true);
                leftButton.buttonPressed = false;
                rightButton.buttonPressed = false;
                leftButton.gameObject.SetActive(true);
                break;
            case "House3":
                rightButton.gameObject.SetActive(true);
                leftButton.buttonPressed = false;
                rightButton.buttonPressed = false;
                leftButton.gameObject.SetActive(true);
                break;
            case "Cafe":
                rightButton.gameObject.SetActive(true);
                leftButton.buttonPressed = false;
                rightButton.buttonPressed = false;
                leftButton.gameObject.SetActive(true);
                break;
            case "Motel":
                rightButton.gameObject.SetActive(true);
                leftButton.buttonPressed = false;
                rightButton.buttonPressed = false;
                leftButton.gameObject.SetActive(true);
                break;
            case "Church":
                rightButton.gameObject.SetActive(false);
                leftButton.buttonPressed = false;
                rightButton.buttonPressed = false;
                leftButton.gameObject.SetActive(true);
                break;
        }
    }

    private void RightButton()
    {
     
            Debug.Log("RightPressed");
            switch (currentLevelName)
            {
                case "House1":
                    level1.DeactivateToRight();
                    break;
                case "House2":
                    level2.DeactivateToRight();
                    break;
                case "House3":
                    level3.DeactivateToRight();
                break;
                case "Cafe":
                    level4.DeactivateToRight();
                break;
                case "Motel":
                    level5.DeactivateToRight();
                break;
        }
        
    }

    private void LeftButton()
    {
            Debug.Log("LeftPressed");

            switch (currentLevelName)
            {
                case "Church":
                    level6.DeactivateToLeft();
                    break;
                case "Motel":
                    level5.DeactivateToLeft();
                    break;
                case "Cafe":
                    level4.DeactivateToLeft();
                    break;
                case "House3":
                    level3.DeactivateToLeft();
                    break;
                case "House2":
                    level2.DeactivateToLeft();
                    break;
            }
        
    }

    private void ActivateNextHouse(string next)
    {
        switch(next)
        {
            case "House1":
                level1.gameObject.SetActive(true);
                break;
            case "House2":
                level2.gameObject.SetActive(true);
                break;
            case "House3":
                level3.gameObject.SetActive(true);
                break;
            case "Cafe":
                level4.gameObject.SetActive(true);
                break;
            case "Motel":
                level5.gameObject.SetActive(true);
                break;
            case "Church":
                level6.gameObject.SetActive(true);
                break;
        }
    }

    private void StartGame()
    {

            fadeAnim.SetBool("fade", true);
            StartCoroutine(LoadLevel(currentLevel));

    }

    private void LockedButton()
    {
        Debug.Log("level locked");
    }

    private void Home()
    {
        fadeAnim.SetBool("fade", true);
        StartCoroutine(LoadLevel("MainMenu"));
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
        level1.OnLevelChange -= ChangeLevel;
        level2.OnLevelChange -= ChangeLevel;
        level3.OnLevelChange -= ChangeLevel;
        level4.OnLevelChange -= ChangeLevel;
        level5.OnLevelChange -= ChangeLevel;
        level6.OnLevelChange -= ChangeLevel;
        level1.OnHouseDeactivated -= ActivateNextHouse;
        level2.OnHouseDeactivated -= ActivateNextHouse;
        level3.OnHouseDeactivated -= ActivateNextHouse;
        level4.OnHouseDeactivated -= ActivateNextHouse;
        level5.OnHouseDeactivated -= ActivateNextHouse;
        level6.OnHouseDeactivated -= ActivateNextHouse;
        leftButton.OnButtonPressed -= LeftButton;
        rightButton.OnButtonPressed -= RightButton;
        playButton.OnPlayButtonPressed -= StartGame;
        homeButton.OnHomePressed -= Home;
        lockedPlayButton.OnPlayButtonPressed -= LockedButton;
    }
}
