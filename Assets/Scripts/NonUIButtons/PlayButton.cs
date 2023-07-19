using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public delegate void PlayButtonPressed();
    public event PlayButtonPressed OnPlayButtonPressed;



    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("push");
        if (OnPlayButtonPressed != null) OnPlayButtonPressed();
    }

}
