using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public delegate void LevelChange(string name, bool complete);
    public event LevelChange OnLevelChange;
    public delegate void HouseDeactivated(string next);
    public event HouseDeactivated OnHouseDeactivated;

    [SerializeField] private Animator animator;
    [SerializeField] private string levelName;
    [SerializeField] private string previousLevel;
    [SerializeField] private string nextLevel;
    public string[] Levels;
    [SerializeField] private GameObject[] elements;

    public bool levelLocked;
    public bool levelComplete;

    private Vector3 defaultScale;
    private void Start()
    {
        CheckLevels();
        defaultScale = transform.localScale;
    }
    private void OnEnable()
    {
        CheckLevels();
        if(OnLevelChange != null) OnLevelChange(levelName, levelComplete);
    }

    private void CheckLevels()
    {
        
            for (int i = 0; i < Levels.Length; i++)
            {
                if(PlayerPrefs.GetInt(Levels[i]) == 1)
                {
                    elements[i].SetActive(true);
                }
                if(PlayerPrefs.GetInt(Levels[Levels.Length - 1]) == 1)
                {
                    levelComplete = true;
                }
                else
                {
                }
            }
            

    }

    private bool LockedLevel()
    {
        return false;
    }

    public void DeactivateToRight()
    {
        animator.SetTrigger("fade");

        StartCoroutine(DeactivateToRightDelay());
    }

    private IEnumerator DeactivateToRightDelay()
    {
        while(transform.localScale.x > 0.01)
        {
            yield return new WaitForEndOfFrame();
            
       
        }
        if (OnHouseDeactivated != null) OnHouseDeactivated(nextLevel);
        this.gameObject.SetActive(false);
        transform.localScale = defaultScale;
    }

    public void DeactivateToLeft()
    {
        animator.SetTrigger("fade");

        StartCoroutine(DeactivateToLeftDelay());
    }

    private IEnumerator DeactivateToLeftDelay()
    {
        while (transform.localScale.x > 0.01)
        {
            yield return new WaitForEndOfFrame();
           
        
        }

        if (OnHouseDeactivated != null) OnHouseDeactivated(previousLevel);
        transform.localScale = defaultScale;
        this.gameObject.SetActive(false);
    }
   
}
