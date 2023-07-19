using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueWordsDesk : MonoBehaviour
{
    public delegate void AllWordsSolved();
    public event AllWordsSolved OnAllWordsSolved;

    [SerializeField] private List<ClueWord> clueWords;
    [SerializeField] private LettersDesk lettersDesk;
    [SerializeField] private RewardedAd rewardedAd;

    private void Start()
    {
        rewardedAd.OnRewardedAdWatched += RevealLetterByHint;
        lettersDesk.OnCheckCurrentWord += CheckWord;
    }

    private void CheckWord(string word)
    {
        for (int i = 0; i < clueWords.Count; i++)
        {
            if (clueWords[i].clueWord == word)
            {
                clueWords[i].RevealWord();
                clueWords.RemoveAt(i);
            }
               
        }

        CheckIfWordsSolved();
    }

    private void CleanSolvedByHint()
    {
        for (int i = 0; i < clueWords.Count; i++)
        {
            if (clueWords[i].wordSolved) clueWords.RemoveAt(i);
        }

        CheckIfWordsSolved();
    }

    private void CheckIfWordsSolved()
    {
        if(clueWords.Count == 0)
        {
            if(OnAllWordsSolved != null) OnAllWordsSolved();
        }
    }

    public void RevealLetterByHint()
    {
        StartCoroutine(Open3Letters(3));
    }

    private IEnumerator Open3Letters(int count)
    {
        while(count > 0)
        {
            if (clueWords.Count > 0)
            {
                int random = Random.Range(0, clueWords.Count);

                clueWords[random].RevealRandomLetter();

                CleanSolvedByHint();
                CheckIfWordsSolved();

            }

            count--;

            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnDisable()
    {
        rewardedAd.OnRewardedAdWatched -= RevealLetterByHint;
        lettersDesk.OnCheckCurrentWord -= CheckWord;
    }
}
