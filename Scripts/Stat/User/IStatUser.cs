using System.Collections.Generic;

namespace PandaEngine.StatSystem
{
    public interface IStatUser
    {
        public void ApplyStatModifier(StatModifier statModifier);
        public void ApplyStatModifiers(List<StatModifier> statModifiers);
        public void RemoveAllModifiersFromSource(IStatModifierSource statModifierSource);
    }
}