using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

[Serializable]
public struct StatModifier
{
    public StatType StatType;
    public StatModifierType StatModifierType;
    public int Value;
    
    public string Description => $"{StatType.displayName} +{Value}{StatModifierType.prefix}";

    public StatModifier(StatType statType, StatModifierType statModifyType, int value)
    {
        StatType = statType;
        StatModifierType = statModifyType;
        Value = value;
    }

    public static StatModifier GenerateFromData(IStatModifierData randomStatData) =>
        new StatModifier(
            randomStatData.StatType,
            randomStatData.StatModifierType,
            Random.Range(randomStatData.MinValue, randomStatData.MaxValue + 1)
        );
    
    public static List<StatModifier> GenerateRandomListFromData(int statCount, IList<StatModifierData> possibleStatData)
    {
        var generatedStats = new List<StatModifier>(statCount);

        for (var i = 0; i < statCount; i++)
        {
            var randomStatData = possibleStatData[Random.Range(0, possibleStatData.Count)];
            possibleStatData.Remove(randomStatData);

            var generatedStat = GenerateFromData(randomStatData);

            generatedStats.Add(generatedStat);
        }

        return generatedStats;
    }
}