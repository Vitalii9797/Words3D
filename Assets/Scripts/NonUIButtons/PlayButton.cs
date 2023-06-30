using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public delegate void PlayButtonPressed();
    public event PlayButtonPressed OnPlayButtonPressed;

    private void OnMouseDown()
    {
        if (OnPlayButtonPressed != null) OnPlayButtonPressed();
    }
}
