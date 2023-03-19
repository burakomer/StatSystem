using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

[Serializable]
public class StatModifier
{
    public StatType StatType;
    public StatModifierType StatModifierType;
    public float Value;
    [HideInInspector] public Object Source;

    public string Description => $"{StatType.displayName} {ValueDescription}";
    public string ValueDescription => $"+{Value:F}{StatModifierType.prefix}";

    public StatModifier(StatType statType, StatModifierType statModifyType, float value)
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

    public static StatModifier GenerateFromTemplate(IStatModifierTemplate randomStatTemplate, Random random) =>
        new(
            randomStatTemplate.StatType,
            randomStatTemplate.StatModifierType,
            Mathf.Lerp(randomStatTemplate.MinValue, randomStatTemplate.MaxValue, (float)random.NextDouble())
        );

    public static List<StatModifier> GenerateRandomListFromTemplate(
        int statCount,
        IList<StatModifierTemplateScriptableDelegate> possibleStatData,
        Random random
    )
    {
        var generatedStats = new List<StatModifier>(statCount);

        for (var i = 0; i < statCount; i++)
        {
            var randomStatData = possibleStatData[random.Next(possibleStatData.Count)];
            possibleStatData.Remove(randomStatData);

            var generatedStat = GenerateFromTemplate(randomStatData, random);

            generatedStats.Add(generatedStat);
        }

        return generatedStats;
    }
}