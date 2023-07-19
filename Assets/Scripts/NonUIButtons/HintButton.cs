using UnityEngine;

public class HintButton : MonoBehaviour
{
   public delegate void OnHintButton();
   public event OnHintButton OnHintButtonClicked;

    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("push");
        if (OnHintButtonClicked != null) OnHintButtonClicked();
    }
}
