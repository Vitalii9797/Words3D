using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : MonoBehaviour
{
    public delegate void OnCancelButton();
    public event OnCancelButton OnCancel;

    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("push");
        if (OnCancel != null) OnCancel();
    }
}
