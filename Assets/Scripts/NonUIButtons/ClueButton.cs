using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueButton : MonoBehaviour
{
    public delegate void ClueButtonPressed(int clueIndex);
    public event ClueButtonPressed OnClueButtonPressed;

    [SerializeField] private int clueNumber;

    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("push");
        if(OnClueButtonPressed != null) OnClueButtonPressed(clueNumber);
    }
}
