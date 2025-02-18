using UnityEngine;

namespace PandaEngine.StatSystem
{
    [CreateAssetMenu(fileName = "Stat Type", menuName = "Panda Engine/Stat System/Core/Stat Type")]
    public class StatType : ScriptableObject
    {
        [SerializeField] private string id;
        [SerializeField] private string displayName;

        public string Id => id;
        public string DisplayName => !string.IsNullOrEmpty(displayName) ? displayName : id;
    }
}