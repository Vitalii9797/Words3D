using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueWord : MonoBehaviour
{
    public string clueWord;

    [SerializeField] LetterTile[] letterTiles;
    [SerializeField] Alphabet alphabet;

    private void Start()
    {
        SetLettersMaterials();
    }

    private void SetLettersMaterials()
    {
        for (int i = 0; i < letterTiles.Length; i++)
        {
            letterTiles[i].SetMaterial(alphabet.Materials[alphabet.Letters.IndexOf(clueWord[i])]);
        }
    }
}
