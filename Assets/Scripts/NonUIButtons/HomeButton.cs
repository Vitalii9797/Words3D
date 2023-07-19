using UnityEngine;

public class HomeButton : MonoBehaviour
{
    public delegate void HomePressed();
    public event HomePressed OnHomePressed;

    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("push");
        if (OnHomePressed != null) OnHomePressed();
    }
}
