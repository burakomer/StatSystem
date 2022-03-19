public class StatModifier
{
    public readonly StatType StatType;
    public readonly StatModifierType StatModifierType;
    public readonly int Value;
    
    public string Description => $"{StatType.displayName} +{Value}{StatModifierType.prefix}";

    public StatModifier(StatType statType, StatModifierType statModifyType, int value)
    {
        StatType = statType;
        StatModifierType = statModifyType;
        Value = value;
    }
}