using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Weapon : MonoBehaviour, IStatModifierSource
{
    [SerializeField] private StatModifier _damage;
    [SerializeField] private List<StatModifier> _statModifiers;

    public Object Source => this;

    public void Initialize(StatModifier damage, List<StatModifier> statModifiers)
    {
        _damage = damage;
        _statModifiers = statModifiers;
        
        _damage.Source = Source;
        foreach (var statModifier in _statModifiers) 
            statModifier.Source = Source;

        var statsText = _statModifiers
            .Select(stat => stat.Description)
            .Aggregate((previous, next) => $"{previous}, {next}");

        print($"<b>{name}</b> | <b>Damage:</b> {_damage.Description} <b>Stats:</b> {statsText}");
    }

    public void ApplyModifiers(IStatUser statUser)
    {
        statUser.ApplyStatModifier(_damage);
        statUser.ApplyStatModifiers(_statModifiers);
    }

    public void RemoveModifiers(IStatUser statUser)
    {
        statUser.RemoveAllModifiersFromSource(this);
    }
}