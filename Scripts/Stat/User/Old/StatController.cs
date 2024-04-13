using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PandaEngine.StatSystem
{
    [DefaultExecutionOrder(-1)]
    public class StatController : MonoBehaviour, IStatUser
    {
        [Header("Settings")]
        [SerializeField] private StatType statType;
        [SerializeField] private float initialBaseValue;

        private Stat stat;

        public Stat Stat => stat;
        public float Value => Stat.Value;

        public UnityEvent<StatValueChangeArgs> OnValueUpdated;
        public UnityEvent<StatValueChangeArgs> OnBaseValueChanged;
        public UnityEvent<StatModifierChangeArgs> OnModifierAdded;
        public UnityEvent<StatModifierChangeArgs> OnModifierRemoved;

        private void Awake()
        {
            stat = new Stat(statType, initialBaseValue);

            stat.OnValueUpdated += OnValueUpdatedCallback;
            stat.OnBaseValueChanged += OnBaseValueChangedCallback;
            stat.OnModifierAdded += OnModifierAddedCallback;
            stat.OnModifierRemoved += OnModifierRemovedCallback;
        }

        public void ApplyStatModifier(StatModifier statModifier)
        {
            if (statModifier.StatType != statType)
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
            stat.RemoveAllModifiersFromSource(statModifierSource.Source);
        }

        private void OnValueUpdatedCallback(StatValueChangeArgs args) =>
            OnValueUpdated?.Invoke(args);

        private void OnBaseValueChangedCallback(StatValueChangeArgs args) =>
            OnBaseValueChanged?.Invoke(args);

        private void OnModifierAddedCallback(StatModifierChangeArgs args) =>
            OnModifierAdded?.Invoke(args);

        private void OnModifierRemovedCallback(StatModifierChangeArgs args) =>
            OnModifierRemoved?.Invoke(args);
    }
}