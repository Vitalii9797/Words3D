using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingStuff : MonoBehaviour
{
    [SerializeField] private string levelName;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(levelName);
    }

}

