using UnityEngine;

public class HomeButton : MonoBehaviour
{
    public delegate void HomePressed();
    public event HomePressed OnHomePressed;

    private void OnMouseDown()
    {
        if(OnHomePressed != null) OnHomePressed();
    }
}
