using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel : MonoBehaviour
{
    public delegate void LoadLevel(string levelToLoad);
    public event LoadLevel OnLoadLevelPressed;

    [SerializeField] private string level;

    private void OnMouseDown()
    {
        if(OnLoadLevelPressed != null) OnLoadLevelPressed(level);
    }
}
