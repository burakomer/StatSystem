using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "RIG/Item/WeaponData")]
public class WeaponData : ScriptableObject 
{
    [Header("Settings")]
    public string itemName;
    public int statCount;

    [Header("Damage")]
    public StatModifierDataStruct baseDamage;

    [Space]
    public List<StatModifierData> possibleStatModifiers;
}