using System.Collections.Generic;

namespace PandaEngine.StatSystem
{
    public interface IStatUser
    {
        void ApplyStatModifier(StatModifier statModifier);
        void ApplyStatModifiers(List<StatModifier> statModifiers);
        void RemoveAllModifiersFromSource(IStatModifierSource statModifierSource);
    }
}