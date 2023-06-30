using UnityEngine;
using TMPro;
using SystemRandom = System.Random;

public class LettersDesk : MonoBehaviour
{
    public delegate void CheckCurrentWord(string word);
    public event CheckCurrentWord OnCheckCurrentWord;

    public string currentWord;

    [SerializeField] private TextMeshProUGUI currentWordText;
    [SerializeField] private string mainWord;
    [SerializeField] private Letter[] mainLetters;
    [SerializeField] private CancelButton cancelButton;
    [SerializeField] private ConfirmButton confirmButton;

    private SystemRandom random = new SystemRandom();

    private void Start()
    {
        currentWord = string.Empty;
        currentWordText.text = currentWord;
        SetLetters();

        cancelButton.OnCancel += CancelSelection;
        confirmButton.OnWordConfirm += ConfirmCurrentWord;
    }

    private void SetLetters()
    {
        ShuffleLetters();

        for (int i = 0; i < mainLetters.Length; i++)
        {
            mainLetters[i].SetLetter(mainWord[i]);
            mainLetters[i].OnLetterPress += UpdateCurrentWord;
        }
    }

    private void ShuffleLetters()
    {

        for (int i = 0; i < mainLetters.Length - 1; i++)
        {
            int j = random.Next(i + 1);

            var temp = mainLetters[j];
            mainLetters[j] = mainLetters[i];
            mainLetters[i] = temp;
        }

    }

    private void UpdateCurrentWord(string letter)
    {
       currentWord += letter;
       currentWordText.text = currentWord;
    }

    private void CancelSelection()
    {
        currentWord = string.Empty;
        currentWordText.text = currentWord;
        for (int i = 0; i < mainLetters.Length; i++)
        {
            mainLetters[i].UnpressLetterAnim();
        }
    }

    private void ConfirmCurrentWord()
    {
        if(OnCheckCurrentWord != null) OnCheckCurrentWord(currentWord);

        CancelSelection();
    }
}
