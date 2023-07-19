using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public delegate void ButtonPressed();
    public event ButtonPressed OnButtonPressed;

    public bool buttonPressed;

    private void OnMouseDown()
    {
        if(!buttonPressed)
        {
            buttonPressed = true;
            GetComponent<Animator>().SetTrigger("push");
            if (OnButtonPressed != null) OnButtonPressed();
        }
        else
        {
            return;
        }
    }
}
