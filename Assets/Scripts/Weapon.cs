using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Weapon : MonoBehaviour
{
    [SerializeField] private StatModifier _damage;
    [SerializeField] private List<StatModifier> _statModifiers;

    public void Initialize(StatModifier damage, List<StatModifier> statModifiers)
    {
        _damage = damage;
        _statModifiers = statModifiers;

        var statsText = _statModifiers
            .Select(stat => stat.Description)
            .Aggregate((previous, next) => $"{previous}, {next}");

        print($"<b>{name}</b> | <b>Damage:</b> {_damage.Description} <b>Stats:</b> {statsText}");
    }
}