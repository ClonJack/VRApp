#if UNITY_EDITOR
using System;
using System.Reflection;
using UnityEditor;
using Object = UnityEngine.Object;

namespace UnrealTeam.Editor
{
    public static class EditorUtils
    {
        public static void OpenFolder(string folderPath)
        {
            Object obj = AssetDatabase.LoadAssetAtPath(folderPath, typeof(Object));
            EditorUtility.FocusProjectWindow();
            var projectBrowser = Type.GetType("UnityEditor.ProjectBrowser,UnityEditor");
            
            object lastInteractedBrowser = projectBrowser
                !.GetField("s_LastInteractedProjectBrowser", BindingFlags.Static | BindingFlags.Public)
                ?.GetValue(null);
            
            MethodInfo showDirectoryMethod = projectBrowser
                .GetMethod("ShowFolderContents", BindingFlags.NonPublic | BindingFlags.Instance);
            
            showDirectoryMethod!.Invoke(lastInteractedBrowser, new object[ ] { obj.GetInstanceID(), true });
        }
    }
}
#endif
