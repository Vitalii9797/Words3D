using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class Alphabet : ScriptableObject
{
    public List<char> Letters;
    public List<Material> Materials;
}