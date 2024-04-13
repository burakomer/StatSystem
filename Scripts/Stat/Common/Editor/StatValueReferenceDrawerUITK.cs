// using System.Collections.Generic;
// using PandaEngine.StatSystem.Utils;
// using UnityEditor;
// using UnityEditor.UIElements;
// using UnityEngine.UIElements;
//
// namespace PandaEngine.StatSystem.Editor
// {
//     [CustomPropertyDrawer(typeof(StatValueReference))]
//     public class StatValueReferenceDrawerUITK : PropertyDrawer
//     {
//         private static List<string> StatReferenceTypes = new()
//         {
//             "Local Stat",
//             "Stats Controller",
//         };
//
//         public override VisualElement CreatePropertyGUI(SerializedProperty property)
//         {
//             var statReferenceType = property.FindPropertyRelative("statReferenceType");
//             var localStat = property.FindPropertyRelative("localStat");
//             var statsController = property.FindPropertyRelative("statsController");
//             var statType = property.FindPropertyRelative("statType");
//
//             var referenceTypeEnum = (StatValueReference.StatReferenceType)statReferenceType.enumValueIndex;
//
//             UIUtils.BoxPropertyContainer(property, out var root, out var content);
//
//             var statsControllerField = new PropertyField(statsController);
//             var statTypeField = new PropertyField(statType);
//             var localStatField = new PropertyField(localStat);
//
//             localStatField.ShowIf(IsLocalStat(referenceTypeEnum));
//             statsControllerField.ShowIf(IsStatsController(referenceTypeEnum));
//             statTypeField.ShowIf(IsStatsController(referenceTypeEnum));
//
//             // AddRefTypeButtons(property, referenceTypeEnum, statReferenceType, localStatField, statsControllerField, statTypeField,
//             //     content);
//
//             AddRefTypeField(property, statReferenceType, localStatField, statsControllerField, statTypeField, content);
//
//             content.Add(statsControllerField);
//             content.Add(statTypeField);
//             content.Add(localStatField);
//
//             return root;
//         }
//
//         private static void AddRefTypeField(SerializedProperty property, SerializedProperty statReferenceType, PropertyField localStatField,
//             PropertyField statsControllerField, PropertyField statTypeField, VisualElement content)
//         {
//             var statReferenceTypeField = new PropertyField(statReferenceType);
//             statReferenceTypeField.RegisterCallback<ChangeEvent<string>>(evt =>
//             {
//                 // statReferenceType.enumValueIndex = StatReferenceTypes.IndexOf(evt.newValue);
//
//                 var newEnumValue = (StatValueReference.StatReferenceType)statReferenceType.enumValueIndex;
//
//                 localStatField.ShowIf(IsLocalStat(newEnumValue));
//                 statsControllerField.ShowIf(IsStatsController(newEnumValue));
//                 statTypeField.ShowIf(IsStatsController(newEnumValue));
//
//                 // property.serializedObject.ApplyModifiedProperties();
//             });
//
//             content.Add(statReferenceTypeField);
//         }
//
//         private static void AddRefTypeButtons(SerializedProperty property, StatValueReference.StatReferenceType referenceTypeEnum,
//             SerializedProperty statReferenceType, PropertyField localStatField, PropertyField statsControllerField,
//             PropertyField statTypeField,
//             VisualElement content)
//         {
//             var statReferenceTypeRadioButtonGroup = new RadioButtonGroup(
//                 "Stat Reference Type",
//                 StatReferenceTypes
//             );
//
//             statReferenceTypeRadioButtonGroup.SetValueWithoutNotify((int)referenceTypeEnum);
//
//             statReferenceTypeRadioButtonGroup.RegisterCallback<ChangeEvent<int>>(evt =>
//             {
//                 statReferenceType.enumValueIndex = evt.newValue;
//
//                 var newEnumValue = (StatValueReference.StatReferenceType)statReferenceType.enumValueIndex;
//
//                 localStatField.ShowIf(IsLocalStat(newEnumValue));
//                 statsControllerField.ShowIf(IsStatsController(newEnumValue));
//                 statTypeField.ShowIf(IsStatsController(newEnumValue));
//
//                 property.serializedObject.ApplyModifiedProperties();
//             });
//
//             content.Add(statReferenceTypeRadioButtonGroup);
//         }
//
//         private static bool IsStatsController(StatValueReference.StatReferenceType newEnumValue)
//         {
//             return newEnumValue == StatValueReference.StatReferenceType.StatsController;
//         }
//
//         private static bool IsLocalStat(StatValueReference.StatReferenceType newEnumValue)
//         {
//             return newEnumValue == StatValueReference.StatReferenceType.LocalStat;
//         }
//     }
// }

