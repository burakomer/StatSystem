using UnityEngine;

public interface IStatModifierSource
{
    Object Source { get; }
    void ApplyModifiers(IStatUser statUser);
    void RemoveModifiers(IStatUser statUser);
}