using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtons : MonoBehaviour
{
    [SerializeField] private ButtonType buttonType;

    [SerializeField] private HouseElements house;

    private void OnMouseDown()
    {
        if(buttonType == ButtonType.OkButton)
        {
            house.OpenElement();
        }
        if(buttonType == ButtonType.CancelButton)
        {
            house.CloseElements();
        }
    }
}

public enum ButtonType
{
    OkButton,
    CancelButton,
}
