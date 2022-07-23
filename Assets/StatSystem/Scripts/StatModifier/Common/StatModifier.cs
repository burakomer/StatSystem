using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

[Serializable]
public class StatModifier
{
    public StatType StatType;
    public StatModifierType StatModifierType;
    public float Value;
    [HideInInspector] public Object Source;

    public string Description => $"{StatType.displayName} {ValueDescription}";
    public string ValueDescription => $"+{Value:F}{StatModifierType.prefix}";

    public StatModifier(StatType statType, StatModifierType statModifyType, int value)
    {
        StatType = statType;
        StatModifierType = statModifyType;
        Value = value;
        Source = null;
    }

    public void SetModifiedValue(ref float finalValue)
    {
        finalValue = StatModifierType.ModifyValue(finalValue, Value);
    }

    public static StatModifier GenerateFromData(IStatModifierData randomStatData) =>
        new(
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