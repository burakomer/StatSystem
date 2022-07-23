using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

[Serializable]
public class Stat
{
    [HideInInspector] public UnityEvent<float> BaseValueChanged;
    [HideInInspector] public UnityEvent<float> ModifierAdded;
    [HideInInspector] public UnityEvent<float> ModifierRemoved;

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

            value = CalculateFinalValue();
            isDirty = false;

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
            baseValue = value;
            isDirty = true;
            BaseValueChanged?.Invoke(Value);
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
        ModifierAdded?.Invoke(Value);
    }

    public bool RemoveModifier(StatModifier mod)
    {
        if (!statModifiers.Remove(mod))
            return false;

        isDirty = true;
        ModifierRemoved?.Invoke(Value);
        return true;
    }

    public bool RemoveAllModifiersFromSource(Object source)
    {
        var didRemove = false;
        for (var i = statModifiers.Count - 1; i >= 0; i--)
        {
            if (statModifiers[i].Source != source)
                continue;

            statModifiers.RemoveAt(i);
            isDirty = true;
            ModifierRemoved?.Invoke(Value);

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