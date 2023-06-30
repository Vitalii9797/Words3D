using UnityEngine;

public class HouseElements : MonoBehaviour
{
    public delegate void BuildingComplete();
    public event BuildingComplete OnBuildingComplete;

    public delegate void ElementAdded();
    public event ElementAdded OnElementAdded;

    [SerializeField] private GameObject[] elements;

    private int openedElements;
  
    void Start()
    {
        openedElements = PlayerPrefs.GetInt("openedElements");

        CloseElements();

        CheckOpenedElements();
    }

    private void CheckOpenedElements()
    {
        for(int i = 0; i < elements.Length; i++)
        {
           if(elements[i].GetComponent<Element>().CheckIfElementOpened() == 1) elements[i].SetActive(true);
        }
    }

    private bool AllOpened()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            if(elements[i].GetComponent<Element>().CheckIfElementOpened() == 0)
            {
                return false;
            }
        }

        return true;
    }

    public void OpenElement(int elementIndex)
    {
        elements[elementIndex].SetActive(true);
        CheckOpenedElements();

        if(AllOpened())
        {
            if (OnBuildingComplete != null) OnBuildingComplete();  
        }
        else
        {
            if (OnElementAdded != null) OnElementAdded();
        }
    }

    public void CloseElements()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].SetActive(false);
        }
    }
}
