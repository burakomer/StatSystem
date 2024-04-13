using System;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace PandaEngine.StatSystem.Editor
{
    [CustomPropertyDrawer(typeof(StatValueReference))]
    public class StatValueReferenceDrawerOdin : OdinValueDrawer<StatValueReference>
    {
        private InspectorProperty statReferenceTypeProperty;
        private InspectorProperty localStatProperty;
        private InspectorProperty statsControllerProperty;
        private InspectorProperty statTypeProperty;

        protected override void Initialize()
        {
            statReferenceTypeProperty = Property.Children["statReferenceType"];
            localStatProperty = Property.Children["localStat"];
            statsControllerProperty = Property.Children["statsController"];
            statTypeProperty = Property.Children["statType"];
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            var referenceTypeEnum = statReferenceTypeProperty.ValueEntry.WeakSmartValue as StatValueReference.StatReferenceType? ??
                                    StatValueReference.StatReferenceType.LocalStat;

            SirenixEditorGUI.BeginBox(label);
            statReferenceTypeProperty.Draw();

            switch (referenceTypeEnum)
            {
                case StatValueReference.StatReferenceType.LocalStat:
                    localStatProperty.Draw();
                    break;
                case StatValueReference.StatReferenceType.StatsController:
                    statsControllerProperty.Draw();
                    statTypeProperty.Draw();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            SirenixEditorGUI.EndBox();
        }
    }
}