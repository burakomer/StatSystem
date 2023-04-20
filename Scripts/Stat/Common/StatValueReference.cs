using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PandaEngine.StatSystem
{
    [Serializable]
    public struct StatValueReference
    {
        public enum StatReferenceType
        {
            Primitive,
            StatController
        }

        public StatReferenceType statReferenceType;

        [ShowIf(nameof(statReferenceType), StatReferenceType.Primitive)] [LabelText("Value")]
        [SerializeField] private float primitiveValue;

        [ShowIf(nameof(statReferenceType), StatReferenceType.StatController)] [LabelText("Value")] [Required]
        [SerializeField] private StatController statController;

        public float Value
        {
            get
            {
                switch (statReferenceType)
                {
                    case StatReferenceType.StatController:
                        return statController.Stat.Value;
                    case StatReferenceType.Primitive:
                    default:
                        return primitiveValue;
                }
            }
        }
    }
}