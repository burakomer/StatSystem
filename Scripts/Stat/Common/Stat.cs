using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PandaEngine.StatSystem
{
    public struct StatValueChangeArgs
    {
        public Stat Stat { get; }
        public float ValueDifference { get; }

        public StatValueChangeArgs(Stat stat, float valueDifference)
        {
            Stat = stat;
            ValueDifference = valueDifference;
        }
    }

    public struct StatModifierChangeArgs
    {
        public Stat Stat { get; }
        public StatModifier StatModifier { get; }

        public StatModifierChangeArgs(Stat stat, StatModifier statModifier)
        {
            Stat = stat;
            StatModifier = statModifier;
        }
    }

    [Serializable]
    public class Stat
    {
        public event Action<StatValueChangeArgs> OnBaseValueChanged;
        public event Action<StatModifierChangeArgs> OnModifierAdded;
        public event Action<StatModifierChangeArgs> OnModifierRemoved;
        public event Action<StatValueChangeArgs> OnValueUpdated;

        [SerializeField] private StatType statType;
        [SerializeField] private float baseValue;
        [SerializeField] private float value;
        [SerializeField] private List<StatModifier> statModifiers;

        public StatType StatType => statType;
        public IReadOnlyList<StatModifier> StatModifiers => statModifiers.AsReadOnly();

        public float Value
        {
            get
            {
                if (!_isDirty)
                    return value;

                UpdateValue(true);
                return value;
            }
        }

        /// <summary>
        /// When set, it will trigger an event to inform subscribers with the new final value.
        /// </summary>
        public float BaseValue => baseValue;

        private bool _isDirty = true;

        private Stat()
        {
            statModifiers = new List<StatModifier>();
        }

        public Stat(StatType statType) : this()
        {
            this.statType = statType;
        }

        public Stat(StatType statType, float baseValue) : this(statType)
        {
            this.baseValue = baseValue;
            UpdateValue();
        }

        public static Stat New(StatSettings statSettings) => new(statSettings.statType, statSettings.initialBaseValue);

        private void UpdateValue(bool withoutNotify = false)
        {
            var previousValue = value;
            value = CalculateFinalValue();
            _isDirty = false;

            if (withoutNotify)
                return;

            var args = new StatValueChangeArgs(this, value - previousValue);
            OnValueUpdated?.Invoke(args);
        }

        private float CalculateFinalValue()
        {
            var statMods = StatModifierGrouping.GroupAndOrderModifiers(statModifiers);

            var finalValue = BaseValue;

            foreach (var mod in statMods)
                mod.SetModifiedValue(ref finalValue);

            if (finalValue > 0f)
                return (float)Math.Round(finalValue, 4);

            finalValue = 0f;
            return finalValue;
        }

        public void SetBaseValue(float newValue)
        {
            var previousBaseValue = baseValue;
            baseValue = newValue;

            var args = new StatValueChangeArgs(this, baseValue - previousBaseValue);
            OnBaseValueChanged?.Invoke(args);

            UpdateValue();
        }

        public void AddModifier(StatModifier mod)
        {
            statModifiers.Add(mod);

            var args = new StatModifierChangeArgs(this, mod);
            OnModifierAdded?.Invoke(args);

            UpdateValue();
        }

        public void AddModifiers(List<StatModifier> mods)
        {
            foreach (var mod in mods)
                AddModifier(mod);
        }

        public bool RemoveModifier(StatModifier mod, bool updateValue = true)
        {
            if (!statModifiers.Remove(mod))
                return false;

            var args = new StatModifierChangeArgs(this, mod);
            OnModifierRemoved?.Invoke(args);

            if (updateValue)
                UpdateValue();

            return true;
        }

        public bool RemoveAllModifiersFromSource(Object source)
        {
            var didRemove = false;
            for (var i = statModifiers.Count - 1; i >= 0; i--)
            {
                if (statModifiers[i].Source != source)
                    continue;

                RemoveModifier(statModifiers[i], false);
                didRemove = true;
            }

            if (didRemove)
                UpdateValue();

            return didRemove;
        }
    }
}