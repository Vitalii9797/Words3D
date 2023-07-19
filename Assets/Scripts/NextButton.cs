using UnityEngine;

public class NextButton : MonoBehaviour
{
   public delegate void NextButtonClicked();
   public event NextButtonClicked OnNextButtonClicked;

    private void OnMouseDown()
    {
        if (OnNextButtonClicked != null) OnNextButtonClicked(); 
        
    }
}
