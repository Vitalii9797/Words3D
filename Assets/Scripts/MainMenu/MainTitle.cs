using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTitle : MonoBehaviour
{
    public delegate void AnimationEnded();
    public event AnimationEnded OnAnimationEnded;

    [SerializeField] private GameObject lastLetter;
    private void Start()
    {
        StartCoroutine(WaitForAnimation());
    }

    private IEnumerator WaitForAnimation()
    {
        while (lastLetter.transform.localPosition.y > 0.1f)
        {
            yield return new WaitForEndOfFrame();
        }

        if (lastLetter.transform.localPosition.y < 0.1f)
        {
            if (OnAnimationEnded != null) OnAnimationEnded();
        }
    }
}
