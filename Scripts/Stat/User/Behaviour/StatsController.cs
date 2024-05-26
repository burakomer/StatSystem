using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PandaEngine.StatSystem
{
    [Serializable]
    public struct StatSettings
    {
        public StatType statType;
        public float initialBaseValue;
    }

    public class StatsController : MonoBehaviour, IStatUser, IStatUserDelegate
    {
        [Header("References")]
        [SerializeField] private StatSystem statSystem;
        [SerializeField] private List<StatSettings> statsSettings;

        [Header("Debug")]
        [SerializeField] private bool showDebugInfo;

        private List<Stat> stats;

        private void Awake()
        {
            stats = statsSettings.ConvertAll(Stat.FromSettings);
        }

        public IStatUser StatUser => this;

        public Stat GetStat(string statId) => GetStat(statsSettings.Find(stat => stat.statType.Id == statId).statType);
        public Stat GetStat(StatType statType) => stats.Find(stat => stat.StatType == statType);

        public void ApplyStatModifierSource(IStatModifierSource statModifierSource)
        {
            var statModifiers = statModifierSource.GetStatModifiersData()
                .ConvertAll(data =>
                {
                    // print($"StatId: {data.StatId}, CalculationId: {data.CalculationId}, Value: {data.Value}");
                    var statType = statSystem.GetStatType(data.StatId);
                    var calculationType = statSystem.GetStatCalculationType(data.CalculationId);
                    // print($"StatType Null: {statType == null}, CalculationType Null: {calculationType == null}");

                    return new StatModifier(statType, calculationType, data.Value, statModifierSource.Source);
                });

            ApplyStatModifiers(statModifiers);
        }

        public void ApplyStatModifier(StatModifier statModifier)
        {
            var stat = stats.Find(stat => stat.StatType == statModifier.StatType);
            stat?.AddModifier(statModifier);
        }

        public void ApplyStatModifiers(List<StatModifier> statModifiers)
        {
            foreach (var statModifier in statModifiers)
                ApplyStatModifier(statModifier);
        }

        public void RemoveStatModifierSource(IStatModifierSource statModifierSource)
        {
            foreach (var stat in stats)
                stat.RemoveAllModifiersFromSource(statModifierSource.Source);
        }

        private void OnGUI()
        {
            if (!showDebugInfo)
                return;

            var sb = new StringBuilder();

            foreach (var stat in stats)
            {
                sb.AppendLine($"<b>{stat.StatType.DisplayName}:</b> {stat.Value} {(stat.BaseValue)}");

                foreach (var statMod in stat.StatModifiers)
                    sb.Append($" {statMod.ValueDescription}");
            }

            var style = new GUIStyle
            {
                fontSize = 24
            };

            GUI.Label(new Rect(0, 0, 2000, 500), sb.ToString(), style);
        }
    }
}