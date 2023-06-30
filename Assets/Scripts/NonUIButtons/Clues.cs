using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clues : MonoBehaviour
{
    [SerializeField] ClueButton clueButton1;
    [SerializeField] ClueButton clueButton2;
    [SerializeField] ClueButton clueButton3;
    [SerializeField] ClueButton clueButton4;
    [SerializeField] ClueButton clueButton5;

    [SerializeField] private GameObject clue1;
    [SerializeField] private GameObject clue2;
    [SerializeField] private GameObject clue3;
    [SerializeField] private GameObject clue4;
    [SerializeField] private GameObject clue5;

    private void Start()
    {
        clueButton1.OnClueButtonPressed += OpenClue;
        clueButton2.OnClueButtonPressed += OpenClue;
        clueButton3.OnClueButtonPressed += OpenClue;
        clueButton4.OnClueButtonPressed += OpenClue;
        clueButton5.OnClueButtonPressed += OpenClue;

    }

    private void OpenClue(int index)
    {
        switch (index)
        {
            case 1:
                clue1.SetActive(true);
                break;
            case 2:
                clue2.SetActive(true);
                break;
            case 3:
                clue3.SetActive(true);
                break;
            case 4:
                clue4.SetActive(true);
                break;
            case 5:
                clue5.SetActive(true);
                break;
        }
    }

    public void CloseClues()
    {
        clue1.SetActive(false);
        clue2.SetActive(false);
        clue3.SetActive(false);
        clue4.SetActive(false);
        clue5.SetActive(false);
    }

    private void OnDisable()
    {
        clueButton1.OnClueButtonPressed -= OpenClue;
        clueButton2.OnClueButtonPressed -= OpenClue;
        clueButton3.OnClueButtonPressed -= OpenClue;
        clueButton4.OnClueButtonPressed -= OpenClue;
        clueButton5.OnClueButtonPressed -= OpenClue;
    }
}
