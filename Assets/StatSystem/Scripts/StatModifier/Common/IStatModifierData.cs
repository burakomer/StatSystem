public interface IStatModifierData
{
    StatType StatType { get; }
    StatModifierType StatModifierType { get; }
    int MinValue { get; }
    int MaxValue { get; }
}