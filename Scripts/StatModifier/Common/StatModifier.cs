using System;
using Object = UnityEngine.Object;

namespace PandaEngine.StatSystem
{
    [Serializable]
    public class StatModifier
    {
        public StatType StatType;
        public StatCalculationType CalculationType;
        public float Value;
        public Object Source;

        public string Description => $"{StatType.DisplayName} {ValueDescription}";
        public string ValueDescription => $"+{Value:F}{CalculationType.Prefix}";

        public StatModifier(StatType statType, StatCalculationType calculationType, float value, Object source)
        {
            StatType = statType;
            CalculationType = calculationType;
            Value = value;
            Source = source;
        }

        public void SetModifiedValue(ref float finalValue)
        {
            finalValue = CalculationType.ModifyValue(finalValue, Value);
        }

        // public static StatModifier GenerateFromTemplate(IStatModifierTemplate randomStatTemplate, Random random) =>
        //     new(
        //         randomStatTemplate.StatType,
        //         randomStatTemplate.StatModifierType,
        //         Mathf.Lerp(randomStatTemplate.MinValue, randomStatTemplate.MaxValue, (float)random.NextDouble())
        //     );

        // public static List<StatModifier> GenerateRandomListFromTemplate(
        //     int statCount,
        //     IList<StatModifierTemplateScriptableDelegate> possibleStatData,
        //     Random random
        // )
        // {
        //     var generatedStats = new List<StatModifier>(statCount);
        //
        //     for (var i = 0; i < statCount; i++)
        //     {
        //         var randomStatData = possibleStatData[random.Next(possibleStatData.Count)];
        //         possibleStatData.Remove(randomStatData);
        //
        //         var generatedStat = GenerateFromTemplate(randomStatData, random);
        //
        //         generatedStats.Add(generatedStat);
        //     }
        //
        //     return generatedStats;
        // }
    }
}