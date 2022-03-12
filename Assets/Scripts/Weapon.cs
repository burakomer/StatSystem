using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private List<Stat> _stats;

    public void Initialize(int damage, List<Stat> stats)
    {
        _damage = damage;
        _stats = stats;

        var statsText = _stats
            .Select(stat => stat.Description)
            .Aggregate((previous, next) => $"{previous}, {next}");

        print($"<b>{name}</b> | <b>Damage:</b> {_damage} <b>Stats:</b> {statsText}");
    }
}