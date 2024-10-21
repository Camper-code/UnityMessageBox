using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace UnityMessageBox.Editor.CustomDependenciesResolving
{
    public class CustonDependenciesResolver
    {
        [InitializeOnLoadMethod]
        [MenuItem("CampStudio/CustomResolver/Resolve Custom Dependencies")]
        public static void Resolve()
        {
            string manifestPath = Application.dataPath + "/../Packages/manifest.json";
            List<string> manifest = File.ReadAllLines(manifestPath).ToList();
            List<string> dependencies = Resources.Load<TextAsset>("CustomDependenciesResolving/dependencies").text.Split('\n').ToList();

            foreach (string dependency in dependencies)
            {
                if (!manifest.Contains(dependency))
                {
                    manifest.Insert(2,dependency);
                }
            }

            File.WriteAllLines(manifestPath, manifest);
        }
    }
}
