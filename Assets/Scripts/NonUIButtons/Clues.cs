using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clues : MonoBehaviour
{
    [SerializeField] private Texture clue1Texture;
    [SerializeField] private Texture clue2Texture;
    [SerializeField] private Texture clue3Texture;
    [SerializeField] private Texture clue4Texture;
    [SerializeField] private Texture clue5Texture;

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

    [SerializeField] private NextButton closeButton1;
    [SerializeField] private NextButton closeButton2;
    [SerializeField] private NextButton closeButton3;
    [SerializeField] private NextButton closeButton4;
    [SerializeField] private NextButton closeButton5;

    private void Start()
    {
        clueButton1.OnClueButtonPressed += OpenClue;
        clueButton2.OnClueButtonPressed += OpenClue;
        clueButton3.OnClueButtonPressed += OpenClue;
        clueButton4.OnClueButtonPressed += OpenClue;
        clueButton5.OnClueButtonPressed += OpenClue;

        closeButton1.OnNextButtonClicked += CloseClues;
        closeButton2.OnNextButtonClicked += CloseClues;
        closeButton3.OnNextButtonClicked += CloseClues;
        closeButton4.OnNextButtonClicked += CloseClues;
        closeButton5.OnNextButtonClicked += CloseClues;

        clue1.GetComponent<MeshRenderer>().material.mainTexture = clue1Texture;
        clue2.GetComponent<MeshRenderer>().material.mainTexture = clue2Texture;
        clue3.GetComponent<MeshRenderer>().material.mainTexture = clue3Texture;
        clue4.GetComponent<MeshRenderer>().material.mainTexture = clue4Texture;
        clue5.GetComponent<MeshRenderer>().material.mainTexture = clue5Texture;
    }

    private void OpenClue(int index)
    {
        switch (index)
        {
            case 1:
                clue2.SetActive(false);
                clue3.SetActive(false);
                clue4.SetActive(false);
                clue5.SetActive(false);
                clue1.SetActive(true);
                break;
            case 2:
                clue1.SetActive(false);
                clue3.SetActive(false);
                clue4.SetActive(false);
                clue5.SetActive(false);
                clue2.SetActive(true);
                break;
            case 3:
                clue1.SetActive(false);
                clue2.SetActive(false);
                clue4.SetActive(false);
                clue5.SetActive(false);
                clue3.SetActive(true);
                break;
            case 4:
                clue1.SetActive(false);
                clue2.SetActive(false);
                clue3.SetActive(false);
                clue5.SetActive(false);
                clue4.SetActive(true);
                break;
            case 5:
                clue1.SetActive(false);
                clue2.SetActive(false);
                clue3.SetActive(false);
                clue4.SetActive(false);
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

        closeButton1.OnNextButtonClicked -= CloseClues;
        closeButton2.OnNextButtonClicked -= CloseClues;
        closeButton3.OnNextButtonClicked -= CloseClues;
        closeButton4.OnNextButtonClicked -= CloseClues;
        closeButton5.OnNextButtonClicked -= CloseClues;
    }
}
