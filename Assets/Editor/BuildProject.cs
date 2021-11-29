using UnityEditor;
using UnityEngine;

public class BuildProject
{
    [MenuItem("Build Platforms/Build All Platforms")]
    public static void Build()
    {
        string path = EditorUtility.SaveFolderPanel("Choose Location to Save", "", "");

        if(path == null)
        {
            return;
        }

        EditorBuildSettingsScene[] level = EditorBuildSettings.scenes;

        string[] levels = new string[level.Length];

        int i = 0;

        foreach (EditorBuildSettingsScene scene in level)
        {
            levels[i] = scene.path;
            Debug.Log(levels[i]);
            i++;
        }

        BuildPipeline.BuildPlayer(levels, path + "/windows/game.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
        BuildPipeline.BuildPlayer(levels, path + "/mac/game.app", BuildTarget.StandaloneOSX, BuildOptions.None);
        BuildPipeline.BuildPlayer(levels, path + "/linux/game.x86_64", BuildTarget.StandaloneLinux64, BuildOptions.None);
    }
}
