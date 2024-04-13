using System;
using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private List<StatSettings> statsSettings;

        [Header("Debug")]
        [SerializeField] private bool showDebugInfo;

        private Dictionary<StatType, Stat> stats;

        private void Awake()
        {
            stats = statsSettings.ToDictionary(settings => settings.statType, Stat.New);
        }

        public IStatUser StatUser => this;

        public Stat GetStat(StatType statType) => stats.GetValueOrDefault(statType);

        public void ApplyStatModifier(StatModifier statModifier)
        {
            if (!stats.TryGetValue(statModifier.StatType, out var stat))
                return;
            stat.AddModifier(statModifier);
        }

        public void ApplyStatModifiers(List<StatModifier> statModifiers)
        {
            foreach (var statModifier in statModifiers)
                ApplyStatModifier(statModifier);
        }

        public void RemoveAllModifiersFromSource(IStatModifierSource statModifierSource)
        {
            foreach (var stat in stats.Values)
                stat.RemoveAllModifiersFromSource(statModifierSource.Source);
        }

        private void OnGUI()
        {
            if (!showDebugInfo)
                return;

            var sb = new StringBuilder();

            foreach (var stat in stats.Values)
            {
                sb.AppendLine($"<b>{stat.StatType.displayName}:</b> {stat.Value} {(stat.BaseValue)}");

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