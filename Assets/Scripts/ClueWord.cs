using System.Collections.Generic;
using UnityEngine;

public class ClueWord : MonoBehaviour
{
    public string clueWord;
    public bool wordSolved;

    [SerializeField] private List<LetterTile> letterTiles;
    [SerializeField] Alphabet alphabet;
    private void Start()
    {
        SetLettersMaterials();
    }

    private void SetLettersMaterials()
    {
        for (int i = 0; i < letterTiles.Count; i++)
        {
            letterTiles[i].SetMaterial(alphabet.Materials[alphabet.Letters.IndexOf(clueWord[i])]);
        }
    }

    public void RevealRandomLetter()
    {
        int random = Random.Range(0, letterTiles.Count);

        letterTiles[random].RevealLetter();
        letterTiles.RemoveAt(random);

        if(letterTiles.Count == 0)
        {
            wordSolved = true;
        }
    }

    public void RevealWord()
    {
        for (int i = 0; i < letterTiles.Count; i++)
        {
            letterTiles[i].RevealLetter();
        }
    }
}
