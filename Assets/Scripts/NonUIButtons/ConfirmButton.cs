using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    public delegate void ConfirmButtonCallback();
    public event ConfirmButtonCallback OnWordConfirm;

    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("push");
        if (OnWordConfirm != null) OnWordConfirm();
    }
}
