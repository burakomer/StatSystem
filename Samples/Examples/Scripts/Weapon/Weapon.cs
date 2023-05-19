using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PandaEngine.StatSystem.Examples
{
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

        public void ApplyModifiers(IStatUserDelegate statUserDelegate)
        {
            statUserDelegate.StatUser.ApplyStatModifier(_damage);
            statUserDelegate.StatUser.ApplyStatModifiers(_statModifiers);
        }

        public void RemoveModifiers(IStatUserDelegate statUserDelegate)
        {
            statUserDelegate.StatUser.RemoveAllModifiersFromSource(this);
        }
    }
}