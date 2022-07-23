using UnityEngine;

/// <summary>
/// Used for generic purposes.
/// </summary>
[CreateAssetMenu(fileName = "StatModifierData", menuName = "RIG/Stats/Common/StatModifierData")]
public class StatModifierData : ScriptableObject, IStatModifierData
{
    [SerializeField] private StatModifierDataStruct data;
    
    public StatType StatType => data.StatType;
    public StatModifierType StatModifierType => data.StatModifierType;
    public float MinValue => data.MinValue;
    public float MaxValue => data.MaxValue;
}