using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

namespace BeginnerJam.Misc
{
    public class BuildTool 
    {
        [MenuItem("Build/Windows Client")]
        public static void BuildWindows()
        {
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = new[] { "Assets/_BeginnerJam/Scenes/Main.unity" };
            buildPlayerOptions.locationPathName = "Build/Client/Client.exe";
            buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
            buildPlayerOptions.options = BuildOptions.None;

            
            BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            BuildSummary summary = report.summary;

            if (summary.result == BuildResult.Succeeded)
            {
                Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            }

            if (summary.result == BuildResult.Failed)
            {
                Debug.Log("Build failed");
            }
        }

        [MenuItem("Build/Windows Server")]
        public static void BuildServer()
        {
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = new[] { "Assets/_BeginnerJam/Scenes/Main.unity" };
            buildPlayerOptions.locationPathName = "Build/Server/Server.exe";
            buildPlayerOptions.target = BuildTarget.StandaloneWindows;
            buildPlayerOptions.subtarget = (int)StandaloneBuildSubtarget.Server;
            buildPlayerOptions.options = BuildOptions.None;

            
            BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            BuildSummary summary = report.summary;

            if (summary.result == BuildResult.Succeeded)
            {
                Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            }

            if (summary.result == BuildResult.Failed)
            {
                Debug.Log("Build failed");
            }
        }
    }
}
