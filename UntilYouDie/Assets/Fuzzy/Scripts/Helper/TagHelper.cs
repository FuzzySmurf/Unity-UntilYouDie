#if (UNITY_EDITOR)
//using UnityEditor;
using UnityEngine;

namespace Fuzzy.Helper
{
    public static class TagHelper
    {
     public static void AddTag(string tag)
        {
            UnityEngine.Object[] asset = UnityEditor.AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
            if ((asset != null) && (asset.Length > 0))
            {
                UnityEditor.SerializedObject so = new UnityEditor.SerializedObject(asset[0]);
                UnityEditor.SerializedProperty tags = so.FindProperty("tags");

                for (int i = 0; i < tags.arraySize; ++i) {
                    if (tags.GetArrayElementAtIndex(i).stringValue == tag) {
                        return;     // Tag already present, nothing to do.
                    }
                }

                tags.InsertArrayElementAtIndex(tags.arraySize);
                tags.GetArrayElementAtIndex(tags.arraySize - 1).stringValue = tag;
                so.ApplyModifiedProperties();
                so.Update();
            }
        }

        public static void RemoveTag(string tag)
        {
            UnityEngine.Object[] asset = UnityEditor.AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
            if ((asset != null) && (asset.Length > 0))
            {
                UnityEditor.SerializedObject so = new UnityEditor.SerializedObject(asset[0]);
                UnityEditor.SerializedProperty tags = so.FindProperty("tags");

                for (int i = 0; i < tags.arraySize; ++i)
                {
                    if (tags.GetArrayElementAtIndex(i).stringValue == tag)
                    {
                        tags.DeleteArrayElementAtIndex(i);
                        Debug.Log("tag: " + tag + " has been removed");
                        so.ApplyModifiedProperties();
                        so.Update();
                        return;     // Tag already present, nothing to do.
                    }
                }
            }
        }
    }
}
#endif