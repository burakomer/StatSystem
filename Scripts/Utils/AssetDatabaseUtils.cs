using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PandaEngine.StatSystem.Utils
{
    public static class AssetDatabaseUtils
    {
        public static T FindAssetInstance<T>(T runtimeInstance) where T : Object
        {
            if (Application.isPlaying)
                return runtimeInstance;

            var instances = FindAssetInstances<T>();
            if (instances.Count > 1)
                Debug.LogWarning($"Multiple {typeof(T)} found in the project. Returning the first one");

            return instances.FirstOrDefault();
        }

        public static T FindAssetInstance<T>() where T : Object
        {
            var instances = FindAssetInstances<T>();
            if (instances.Count > 1)
                Debug.LogWarning($"Multiple {typeof(T)} found in the project. Returning the first one");

            return instances.FirstOrDefault();
        }

        public static List<T> FindAssetInstances<T>() where T : Object
        {
#if UNITY_EDITOR
            var guids = AssetDatabase.FindAssets("t:" + typeof(T), new[] { "Assets" });
            if (guids.Length == 0)
            {
                Debug.LogError($"No {typeof(T)} found in the project");
                return null;
            }

            var instances = new List<T>();
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var instance = AssetDatabase.LoadAssetAtPath<T>(path);
                instances.Add(instance);
            }

            return instances;
#else
            return new List<T>();
#endif
        }
    }
}