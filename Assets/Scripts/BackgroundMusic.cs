using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("music");

        if (music.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }
}