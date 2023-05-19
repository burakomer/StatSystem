using UnityEngine;

namespace PandaEngine.StatSystem
{
    public interface IStatModifierSource
    {
        Object Source { get; }
        void ApplyModifiers(IStatUserDelegate statUserDelegate);
        void RemoveModifiers(IStatUserDelegate statUserDelegate);
    }
}