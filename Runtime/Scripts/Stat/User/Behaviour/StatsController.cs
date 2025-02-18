using System.Collections.Generic;
using System.Text;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PandaEngine.StatSystem
{
    public class StatsController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private StatSystem statSystem;
        [SerializeField] private List<StatSettings> statsSettings;

        [Header("Debug")]
        [SerializeField] private bool showDebugInfo;

        [SerializeField] [ReadOnly] private List<Stat> stats;

        #region PUBLIC PROPERTIES

        public IReadOnlyList<Stat> Stats => stats;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            stats = statsSettings.ConvertAll(settings => Stat.FromSettings(settings));
        }

        #endregion

        #region PRIVATE METHODS

        private void ApplyStatModifier(StatModifier statModifier)
        {
            var stat = stats.Find(stat => stat.StatType == statModifier.StatType);
            stat?.AddModifier(statModifier);
        }

        private void ApplyStatModifiers(List<StatModifier> statModifiers)
        {
            foreach (var statModifier in statModifiers)
                ApplyStatModifier(statModifier);
        }

        private void ApplyStatModifiersFromSource(IStatModifierSource statModifierSource)
        {
            var statModifiers = GetNewStatModifiersFromSource(statModifierSource);
            ApplyStatModifiers(statModifiers);
        }

        private List<StatModifier> GetNewStatModifiersFromSource(IStatModifierSource statModifierSource)
        {
            return statModifierSource.GetStatModifiersData()
                .ConvertAll(data =>
                {
                    var statType = statSystem.GetStatType(data.StatId);
                    var calculationType = statSystem.GetStatCalculationType(data.CalculationId);
                    return new StatModifier(statType, calculationType, data.Value, statModifierSource.Source);
                });
        }

        private void RemoveAllStatModifiersFromSource(IStatModifierSource statModifierSource)
        {
            foreach (var stat in stats)
                stat.RemoveAllModifiersFromSource(statModifierSource.Source);
        }

        #endregion

        #region STAT METHODS

        public Stat GetStat(string statId) => GetStat(statsSettings.Find(stat => stat.statType.Id == statId).statType);
        public Stat GetStat(StatType statType) => stats.Find(stat => stat.StatType == statType);

        public void AddOrUpdateStat(IStatSettings settings)
        {
            var stat = GetStat(settings.StatType);
            if (stat != null)
            {
                stat.SetBaseValue(settings.InitialBaseValue);
                return;
            }

            stats.Add(Stat.FromSettings(settings));
        }

        #endregion

        #region STAT MODIFIER SOURCE METHODS

        public void ApplyStatModifierSource(IStatModifierSource statModifierSource)
        {
            ApplyStatModifiersFromSource(statModifierSource);
            statModifierSource.OnStatModifiersChanged += UpdateStatModifierSource;
        }

        private void UpdateStatModifierSource(IStatModifierSource statModifierSource)
        {
            RemoveAllStatModifiersFromSource(statModifierSource);
            ApplyStatModifiersFromSource(statModifierSource);
        }

        public void RemoveStatModifierSource(IStatModifierSource statModifierSource)
        {
            RemoveAllStatModifiersFromSource(statModifierSource);

            statModifierSource.OnStatModifiersChanged -= UpdateStatModifierSource;
        }

        #endregion

        #region EDITOR METHODS

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

        #endregion
    }
}