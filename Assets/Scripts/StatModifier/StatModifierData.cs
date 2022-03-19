using UnityEngine;

[CreateAssetMenu(fileName = "StatModifierData", menuName = "RIG/Base/StatModifierData")]
public class StatModifierData : ScriptableObject 
{
    public StatType statType;
    public StatModifierType statModifierType;
    public int minValue;
    public int maxValue;
}