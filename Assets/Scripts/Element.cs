using UnityEngine;

public class Element : MonoBehaviour
{
    public string elementKey;

    [SerializeField] private ParticleSystem particle;


    private void OnEnable()
    {
        PlayParticles();
    }

    public void PlayParticles()
    {
        if(PlayerPrefs.GetInt(elementKey) == 0)
        {
            particle.Play();
            PlayerPrefs.SetInt(elementKey, 1);
        }
    }

    public int CheckIfElementOpened()
    {
        return PlayerPrefs.GetInt(elementKey);
    }
}
