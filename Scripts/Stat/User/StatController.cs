using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-1)]
public class StatController : MonoBehaviour, IStatUser
{
    [Header("Settings")]
    [SerializeField] private StatType statType;
    [SerializeField] private float initialBaseValue;

    private Stat stat;

    public Stat Stat => stat;
    public float Value => Stat.Value;

    public UnityEvent<float> BaseValueChanged => stat.BaseValueChanged;
    public UnityEvent<float> ModifierAdded => stat.ModifierAdded;
    public UnityEvent<float> ModifierRemoved => stat.ModifierRemoved;

    private void Awake()
    {
        stat = new Stat(statType, initialBaseValue);
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
}