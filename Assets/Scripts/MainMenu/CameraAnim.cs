using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour
{
    public delegate void CameraAnimationEnded();
    public event CameraAnimationEnded OnCameraAnimationEnded;

    private void Start()
    {
        StartCoroutine(WaitForAnimation());
    }

    private IEnumerator WaitForAnimation()
    {
        while(this.gameObject.transform.localPosition.y > 0.1f)
        {
            yield return new WaitForEndOfFrame();
        }

        if(this.gameObject.transform.localPosition.y < 0.1f)
        {
            if(OnCameraAnimationEnded != null) OnCameraAnimationEnded();
        }
    }

}
