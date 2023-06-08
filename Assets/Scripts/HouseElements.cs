using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseElements : MonoBehaviour
{
    [SerializeField] private GameObject[] elements;

    private int elementIndex;
   
    void Start()
    {
        CloseElements();
    }

    public void OpenElement()
    {
        if(elements.Length > elementIndex)
        {
            elements[elementIndex].SetActive(true);

            elementIndex++;
        }
        else
        {
            Debug.Log("All elements opened");
        }
    }

    public void CloseElements()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].SetActive(false);
        }
        elementIndex = 0;
    }
}
