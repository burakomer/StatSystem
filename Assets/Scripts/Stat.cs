public class Stat
{
    public readonly StatType StatType;
    public readonly StatModifyType StatModifyType;
    public readonly int Value;

    public Stat(StatType statType, StatModifyType statModifyType, int value)
    {
        StatType = statType;
        StatModifyType = statModifyType;
        Value = value;
    }

    public string Description => $"{StatType} +{Value}{(StatModifyType == StatModifyType.Percent ? "%" : "")}";
}