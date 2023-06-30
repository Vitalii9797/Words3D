using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLevel : MonoBehaviour
{
    public delegate void LevelChange(string level);
    public event LevelChange OnLevelChange;

    [SerializeField] private string houseName;

    private void OnEnable()
    {
        if(OnLevelChange != null) OnLevelChange(houseName);
    }

}
