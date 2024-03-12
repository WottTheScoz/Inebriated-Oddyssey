using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public CharacterClass[] Character;

    public int CharacterCount { get { return Character.Length; } }

    public CharacterClass GetCharacter(int index)
    {
        return Character[index];
    }
}
