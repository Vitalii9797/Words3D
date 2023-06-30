using UnityEngine;

public class Letter : MonoBehaviour
{
    public delegate void LetterPressed(string letter);
    public event LetterPressed OnLetterPress;

    [SerializeField] private Alphabet alphabet;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Animator letterAnim;

    private string letterValue;
    private bool letterPressed;

    private const string animParameter = "Pressed";

    public void SetLetter(char letter)
    {
        letterValue = letter.ToString();
        meshRenderer.material = alphabet.Materials[alphabet.Letters.IndexOf(letter)];
    }

    private void OnMouseDown()
    {
        if(!letterPressed)
        {
            letterPressed = true;

            if (OnLetterPress != null) OnLetterPress(letterValue);

            PressLetterAnim();
        }
    }

    public void PressLetterAnim()
    {
        letterAnim.SetBool(animParameter, true);
    }

    public void UnpressLetterAnim()
    {
       letterAnim.SetBool(animParameter, false);
        letterPressed = false;
    }
}
