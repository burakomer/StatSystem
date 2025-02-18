using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace PandaEngine.StatSystem.Editor
{
    [CustomPropertyDrawer(typeof(StatValueReference))]
    public class StatDrawerOdin : OdinValueDrawer<Stat>
    {
        private InspectorProperty statTypeProperty;
        private InspectorProperty baseValueProperty;
        private InspectorProperty valueProperty;
        private InspectorProperty statModifiersProperty;

        protected override void Initialize()
        {
            statTypeProperty = Property.Children["statType"];
            baseValueProperty = Property.Children["baseValue"];
            valueProperty = Property.Children["value"];
            statModifiersProperty = Property.Children["statModifiers"];
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            SirenixEditorGUI.BeginBox(label);
            statTypeProperty.Draw();
            baseValueProperty.Draw();
            valueProperty.Draw();
            statModifiersProperty.Draw();
            SirenixEditorGUI.EndBox();
        }
    }
}