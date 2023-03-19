public interface IStatModifierTemplate
{
    StatType StatType { get; }
    StatModifierType StatModifierType { get; }
    float MinValue { get; }
    float MaxValue { get; }
}