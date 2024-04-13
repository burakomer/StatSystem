using UnityEngine.UIElements;

namespace PandaEngine.StatSystem.Utils
{
    public static class VisualElementExtensions
    {
        public static void ShowIf(this VisualElement element, bool value) =>
            element.style.display = value ? DisplayStyle.Flex : DisplayStyle.None;
    }
}