using UnityEngine;

/// <summary>
/// Used for generic purposes.
/// </summary>
[CreateAssetMenu(fileName = "StatModifierTemplate", menuName = "RIG/Stats/Common/StatModifierTemplate")]
public class StatModifierTemplateScriptableDelegate : ScriptableObject, IStatModifierTemplate
{
    [SerializeField] private StatModifierTemplateStruct template;
    
    public StatType StatType => template.StatType;
    public StatModifierType StatModifierType => template.StatModifierType;
    public float MinValue => template.MinValue;
    public float MaxValue => template.MaxValue;
}