using UnityEngine;

public class RightButton : MonoBehaviour
{
    public delegate void RightButtonPressed();
    public event RightButtonPressed OnRightButtonPressed;

    private void OnMouseDown()
    {
        if(OnRightButtonPressed != null) OnRightButtonPressed();
    }
}
