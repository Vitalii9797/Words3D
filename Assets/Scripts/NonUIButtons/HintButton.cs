using UnityEngine;

public class HintButton : MonoBehaviour
{
   public delegate void OnHintButton();
   public event OnHintButton OnHintButtonClicked;

    private void OnMouseDown()
    {
        if (OnHintButtonClicked != null) OnHintButtonClicked();
    }
}
