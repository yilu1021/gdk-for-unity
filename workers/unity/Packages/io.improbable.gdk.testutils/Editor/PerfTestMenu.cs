using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Improbable.Gdk.TestUtils.Editor
{
    public class PerfTestMenu
    {
        private const string XmlFileName = "TestResults.xml";
        private const string JsonFileName = "PerformanceTestResults.json";

        //hardcoded in PerformanceTestRunSaver.cs
        private static readonly string XmlPath = Path.Combine(Application.persistentDataPath, XmlFileName);
        private static readonly string JsonPath = Path.Combine(Application.persistentDataPath, JsonFileName);

        private static readonly string ResultsPath = Path.Combine(Application.dataPath, "..", "perftest", "results");

        [MenuItem("SpatialOS/Performance Tests/Export Results")]
        public static void ExportResults()
        {
            var currentTime = DateTime.Now.ToString("s").Replace(":", "_");
            var outputDir = Path.Combine(ResultsPath, currentTime);

            if (!File.Exists(XmlPath) || !File.Exists(JsonPath))
            {
                Debug.LogError("No results to export.");
                return;
            }

            Directory.CreateDirectory(outputDir);
            File.Copy(XmlPath, Path.Combine(outputDir, XmlFileName));
            File.Copy(JsonPath, Path.Combine(outputDir, JsonFileName));
        }

        [MenuItem("SpatialOS/Performance Tests/Clear Results")]
        public static void ClearResults()
        {
            if (Directory.Exists(ResultsPath))
            {
                Directory.Delete(ResultsPath, true);
            }
        }
    }
}
