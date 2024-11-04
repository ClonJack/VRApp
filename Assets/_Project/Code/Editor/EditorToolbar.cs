#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityToolbarExtender;
using UnrealTeam.VR.Data.Constant;

namespace UnrealTeam.Editor
{
    [InitializeOnLoad]
    public class EditorToolbar
    {
        private const string _toggleKey = "BootFromAnyScene_ToggleChecked";
        private const string _configsPath = "Assets/_Project/Bundles/Configs";
        private const string _prefabsPath = "Assets/_Project/Bundles/Prefabs";
        private static bool _bootToggleChecked;
 
        
        static EditorToolbar()
        {
            _bootToggleChecked = EditorPrefs.GetBool(_toggleKey, true);
 
            ToolbarExtender.LeftToolbarGUI.Add(AddToolbarGUI);
            EditorApplication.playModeStateChanged += Run;
        }
 
        private static void AddToolbarGUI()
        {
            GUILayout.FlexibleSpace();
            bool newToggleChecked = GUILayout.Toggle(_bootToggleChecked, "Boot Scene");
            if (newToggleChecked != _bootToggleChecked)
            {
                _bootToggleChecked = newToggleChecked;
                EditorPrefs.SetBool(_toggleKey, _bootToggleChecked);
            }

            if (GUILayout.Button(new GUIContent("Configs", "Open Configs Folder"))) 
                EditorUtils.OpenFolder(_configsPath);
            
            if (GUILayout.Button(new GUIContent("Prefabs", "Open Prefabs Folder"))) 
                EditorUtils.OpenFolder(_prefabsPath);
        }

        private static void Run(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.EnteredPlayMode)
                return;

            EditorApplication.playModeStateChanged -= Run;
            if (!_bootToggleChecked)
                return;
            
            var currentScene = SceneManager.GetActiveScene();
            if (IsBootScene(currentScene))
                return;
            
            LoadBootScene();
        }

        private static bool IsBootScene(Scene currentScene) 
            => currentScene.name == SceneNames.Boot;
        
        private static bool IsSceneInBuild(Scene currentScene) 
            => EditorBuildSettings.scenes.Any(s => s.path == currentScene.path);
        
        private static void LoadBootScene() 
            => SceneManager.LoadScene(SceneNames.Boot);
    }
}
#endif