using UnityEngine;

public class LeftButton : MonoBehaviour
{
    public delegate void LeftButtonPressed();
    public event LeftButtonPressed OnLeftButtonPressed;

    private void OnMouseDown()
    {
        if (OnLeftButtonPressed != null) OnLeftButtonPressed();
    }
}
