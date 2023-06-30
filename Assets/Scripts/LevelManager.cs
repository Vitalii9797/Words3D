using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private HouseElements houseElements;
    [SerializeField] private ClueWordsDesk clueWordsDesk;
    [SerializeField] private HomeButton homeButton;
    [SerializeField] private HomeButton BigHomeButton;
    [SerializeField] private GameObject levelCompleteText;
    [SerializeField] private int partOfLevel;
    [SerializeField] private string nextLevel;
    [SerializeField] private Image fadeImage;
    [SerializeField] private Animator fadeAnim;
    [SerializeField] private Animator cluewordsAnim;
    [SerializeField] private Animator downButtonsAnim;
    [SerializeField] private Animator letterDeskAnim;

    private string moveAwayTrigger = "moveaway";
    void Start()
    {
        homeButton.OnHomePressed += HomeButton;
        BigHomeButton.OnHomePressed += HomeButton;
        clueWordsDesk.OnAllWordsSolved += OpenNextElement;
        houseElements.OnBuildingComplete += LevelComplete;
        houseElements.OnElementAdded += LoadNextLevel;
    }

    private void OpenNextElement()
    {
        houseElements.OpenElement(partOfLevel);
    }

    private void LevelComplete()
    {
        ClearDisplay();
        Debug.Log("Level complete!");
    }

    private void HomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void LoadNextLevel()
    {
        StartCoroutine(FadeDelay());
    }

    private IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(2);

        fadeAnim.SetBool("fade", true);
        StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {
        while(fadeImage.color.a < 0.99f)
        {
            yield return new WaitForEndOfFrame();
        }

        if(fadeImage.color.a > 0.99f) SceneManager.LoadScene(nextLevel);
    }

    private void OnDisable()
    {
        homeButton.OnHomePressed -= HomeButton;
        BigHomeButton.OnHomePressed -= HomeButton;
        clueWordsDesk.OnAllWordsSolved -= OpenNextElement;
        houseElements.OnBuildingComplete -= LevelComplete;
        houseElements.OnElementAdded -= LoadNextLevel;
    }

    private void ClearDisplay()
    {
        cluewordsAnim.SetTrigger(moveAwayTrigger);
        downButtonsAnim.SetTrigger(moveAwayTrigger);
        letterDeskAnim.SetTrigger(moveAwayTrigger);

        StartCoroutine(ClearDisplayCor());
    }

    private IEnumerator ClearDisplayCor()
    {
        while(letterDeskAnim.gameObject.transform.position.y > -19.8f)
        {
            yield return new WaitForEndOfFrame();
        }

            BigHomeButton.gameObject.SetActive(true);
            levelCompleteText.SetActive(true);
    }
}
