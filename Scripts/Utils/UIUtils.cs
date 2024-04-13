using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace PandaEngine.StatSystem.Utils
{
    public static class UIUtils
    {
        public static VisualElement BoxPropertyContainer(SerializedProperty property, out Box root, out VisualElement content,
            bool rootMargin = true, bool contentPadding = true
        )
        {
            root = new Box();
            root.style.borderBottomColor = new Color(0.5f, 0.5f, 0.5f);
            root.style.borderBottomWidth = 1;
            // root.style.borderBottomLeftRadius = 5;
            // root.style.borderBottomRightRadius = 5;
            root.style.borderTopColor = new Color(0.5f, 0.5f, 0.5f);
            root.style.borderTopWidth = 1;
            // root.style.borderTopLeftRadius = 5;
            // root.style.borderTopRightRadius = 5;
            root.style.borderLeftColor = new Color(0.5f, 0.5f, 0.5f);
            root.style.borderLeftWidth = 1;
            root.style.borderRightColor = new Color(0.5f, 0.5f, 0.5f);
            root.style.borderRightWidth = 1;

            if (rootMargin)
            {
                root.style.marginBottom = 5;
                root.style.marginTop = 5;
            }

            var label = new Label(property.displayName);
            label.style.unityFontStyleAndWeight = FontStyle.Bold;
            label.style.backgroundColor = new Color(0.15f, 0.15f, 0.15f);
            // root.style.borderTopLeftRadius = 5;
            // root.style.borderTopRightRadius = 5;
            label.style.paddingBottom = 5;
            label.style.paddingTop = 5;
            label.style.paddingLeft = 5;
            label.style.paddingRight = 5;

            root.Add(label);

            content = new VisualElement();
            // content.style.marginBottom = 5;
            // content.style.marginTop = 5;
            // content.style.marginLeft = 5;
            // content.style.marginRight = 5;

            if (contentPadding)
            {
                content.style.paddingBottom = 5;
                content.style.paddingTop = 5;
                content.style.paddingLeft = 5;
                content.style.paddingRight = 5;
            }

            root.Add(content);
            return content;
        }
    }
}