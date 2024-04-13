// using PandaEngine.StatSystem.Utils;
// using UnityEditor;
// using UnityEditor.UIElements;
// using UnityEngine.UIElements;
//
// namespace PandaEngine.StatSystem.Editor
// {
//     [CustomPropertyDrawer(typeof(Stat))]
//     public class StatDrawerUITK : PropertyDrawer
//     {
//         public override VisualElement CreatePropertyGUI(SerializedProperty property)
//         {
//             UIUtils.BoxPropertyContainer(property, out var root, out var content);
//
//             var statType = property.FindPropertyRelative("statType");
//             var baseValue = property.FindPropertyRelative("baseValue");
//             var value = property.FindPropertyRelative("value");
//             var statModifiers = property.FindPropertyRelative("statModifiers");
//
//             var statTypeField = new PropertyField(statType);
//             var baseValueField = new PropertyField(baseValue);
//             var valueField = new PropertyField(value);
//             var statModifiersField = new PropertyField(statModifiers);
//
//             content.Add(statTypeField);
//             content.Add(baseValueField);
//             content.Add(valueField);
//             content.Add(statModifiersField);
//
//             return root;
//         }
//     }
// }

