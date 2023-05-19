using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PandaEngine.StatSystem
{
    public class StatArgs
    {
        public Stat Stat { get; }

        public StatArgs(Stat stat)
        {
            Stat = stat;
        }
    }

    public class StatValueChangeArgs : StatArgs
    {
        public float ValueDifference { get; }

        public StatValueChangeArgs(Stat stat, float valueDifference) : base(stat)
        {
            ValueDifference = valueDifference;
        }
    }

    public class StatModifierChangeArgs : StatArgs
    {
        public StatModifier StatModifier { get; }

        public StatModifierChangeArgs(Stat stat, StatModifier statModifier) : base(stat)
        {
            StatModifier = statModifier;
        }
    }

    [Serializable]
    public class Stat
    {
        public event Action<StatValueChangeArgs> OnBaseValueChanged;
        public event Action<StatValueChangeArgs> OnValueUpdated;
        public event Action<StatModifierChangeArgs> OnModifierAdded;
        public event Action<StatModifierChangeArgs> OnModifierRemoved;

        [Header("State")]
        [SerializeField] private StatType statType;
        [SerializeField] private float baseValue;
        [SerializeField] private float value;
        [SerializeField] private List<StatModifier> statModifiers;

        private bool isDirty;

        public StatType StatType => statType;
        public IReadOnlyList<StatModifier> StatModifiers => statModifiers.AsReadOnly();

        public float Value
        {
            get
            {
                if (!isDirty)
                    return value;

                var previousValue = value;
                value = CalculateFinalValue();
                isDirty = false;

                var args = new StatValueChangeArgs(this, value - previousValue);
                OnValueUpdated?.Invoke(args);

                return value;
            }
        }

        /// <summary>
        /// When set, it will trigger an event to inform subscribers with the new final value.
        /// </summary>
        public float BaseValue
        {
            get => baseValue;
            set
            {
                var previousBaseValue = baseValue;
                baseValue = value;
                isDirty = true;

                var args = new StatValueChangeArgs(this, baseValue - previousBaseValue);
                OnBaseValueChanged?.Invoke(args);
            }
        }

        private Stat()
        {
            statModifiers = new List<StatModifier>();
            isDirty = true;
        }

        public Stat(StatType statType) : this()
        {
            this.statType = statType;
        }

        public Stat(StatType statType, float baseValue) : this(statType)
        {
            this.baseValue = baseValue;
        }

        public void AddModifier(StatModifier mod)
        {
            statModifiers.Add(mod);
            isDirty = true;

            var args = new StatModifierChangeArgs(this, mod);
            OnModifierAdded?.Invoke(args);
        }

        public bool RemoveModifier(StatModifier mod)
        {
            if (!statModifiers.Remove(mod))
                return false;

            isDirty = true;

            var args = new StatModifierChangeArgs(this, mod);
            OnModifierRemoved?.Invoke(args);
            return true;
        }

        public bool RemoveAllModifiersFromSource(Object source)
        {
            var didRemove = false;
            for (var i = statModifiers.Count - 1; i >= 0; i--)
            {
                if (statModifiers[i].Source != source)
                    continue;

                RemoveModifier(statModifiers[i]);
                didRemove = true;
            }

            return didRemove;
        }

        public float CalculateFinalValue()
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
    }
}