using System;
using UnityEngine;

[Serializable]
public struct StatModifierDataStruct : IStatModifierData
{
    [SerializeField] private StatType statType;
    [SerializeField] private StatModifierType statModifierType;
    [SerializeField] private int minValue;
    [SerializeField] private int maxValue;
    
    public StatType StatType => statType;
    public StatModifierType StatModifierType => statModifierType;
    public int MinValue => minValue;
    public int MaxValue => maxValue;
}