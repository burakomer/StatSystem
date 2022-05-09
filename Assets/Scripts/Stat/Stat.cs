using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[Serializable]
public class Stat
{
    public delegate void StatEvent(float newValue);

    public event StatEvent BaseValueChanged;
    public event StatEvent ModifierAdded;
    public event StatEvent ModifierRemoved;

    public float Value
    {
        get
        {
            if (_isDirty || Math.Abs(_baseValue - _lastBaseValue) > 0)
            {
                _lastBaseValue = _baseValue;
                _value = CalculateFinalValue();
                _isDirty = false;
            }

            return _value;
        }
    }

    /// <summary>
    /// When set, it will trigger an event to inform subscribers with the new final value.
    /// </summary>
    public float BaseValue
    {
        get => _baseValue;
        set
        {
            _baseValue = value;
            BaseValueChanged?.Invoke(Value);
        }
    }

    [SerializeField] private float _baseValue;
    public object baseValueSource;
    public readonly ReadOnlyCollection<StatModifier> statModifiers;

    [SerializeField] private float _value;
    private float _lastBaseValue;
    private bool _isDirty;
    [SerializeField] private List<StatModifier> _statModifiers;

    public Stat()
    {
        _statModifiers = new List<StatModifier>();
        statModifiers = _statModifiers.AsReadOnly();
        _isDirty = true;
    }

    public Stat(float baseValue, object baseValueSource) : this()
    {
        BaseValue = baseValue;
        this.baseValueSource = baseValueSource;
        _lastBaseValue = baseValue;
    }

    public void AddModifier(StatModifier mod)
    {
        _statModifiers.Add(mod);
        ModifierAdded?.Invoke(Value);
        _isDirty = true;
    }

    public bool RemoveModifier(StatModifier mod)
    {
        if (_statModifiers.Remove(mod))
        {
            _isDirty = true;
            ModifierRemoved?.Invoke(Value);
            return true;
        }

        return false;
    }

    public bool RemoveAllModifiersFromSource(object source)
    {
        var didRemove = false;
        for (var i = _statModifiers.Count - 1; i >= 0; i--)
        {
            if (_statModifiers[i].source == source)
            {
                _statModifiers.RemoveAt(i);
                _isDirty = true;
                didRemove = true;
                ModifierRemoved?.Invoke(Value);
            }
        }

        return didRemove;
    }

    public float CalculateFinalValue()
    {
        _statModifiers.Sort(CompareModifierOrder);

        var finalValue = _baseValue;
        var finalBasePercent = 0f;
        var finalPercent = 0f;
        var finalFullPercent = 0f;
        var fullPercentModExists = false;

        for (var i = 0; i < _statModifiers.Count; i++)
        {
            var mod = _statModifiers[i];

            if (mod.type == StatModType.BaseFlat || mod.type == StatModType.Flat)
            {
                finalValue += mod.value;
            }
            else if (mod.type == StatModType.BasePercent)
            {
                finalBasePercent += mod.value;
                if (i + 1 == _statModifiers.Count || _statModifiers[i + 1].type != StatModType.BasePercent)
                    finalValue *= 1 + finalBasePercent;
            }
            else if (mod.type == StatModType.Percent)
            {
                finalPercent += mod.value;
                if (i + 1 == _statModifiers.Count || _statModifiers[i + 1].type != StatModType.Percent)
                    finalValue *= 1 + finalPercent;
            }
            else if (mod.type == StatModType.FullPercent)
            {
                fullPercentModExists = true;
                finalFullPercent += mod.value;
            }
        }

        if (finalFullPercent > 0 || fullPercentModExists) finalValue *= finalFullPercent;

        if (finalValue <= 0f)
        {
            finalValue = 0f;
            return finalValue;
        }

        return (float) Math.Round(finalValue, 4);
    }
}