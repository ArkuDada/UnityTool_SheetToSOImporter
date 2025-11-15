using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;

namespace Editor.SheetTool
{
    public class SheetImporter : EditorWindow
    {
        private string url;
        private int selectedClassIndex;
        private Type[] availableClasses;
        private string[] classNames;

        [MenuItem("Tools/Sheet Importer")]
        public static void Open()
        {
            GetWindow<SheetImporter>("Sheet Importer");
        }

        private void OnEnable()
        {
            url = PlayerPrefs.GetString("Last_valid_url", "https://example.com/data.json");

            // Find all classes in the current assembly that are serializable
            availableClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsClass && type.Namespace == "Editor.SheetTool")
                .ToArray();

            classNames = availableClasses.Select(type => type.Name).ToArray();
        }

        private void OnGUI()
        {
            url = EditorGUILayout.TextField("JSON URL", url);

            // Dropdown for selecting the class
            selectedClassIndex = EditorGUILayout.Popup("Select Class", selectedClassIndex, classNames);

            if(GUILayout.Button("Fetch & Generate"))
            {
                Fetch();
            }
        }

        private async void Fetch()
        {
            string json = await HttpGet(url);
            Debug.Log(json);

            PlayerPrefs.SetString("Last_valid_url", url);

            // Dynamically deserialize into the selected class
            Type selectedClass = availableClasses[selectedClassIndex];
            // object json = JsonUtility.FromJson(data, selectedClass);
            object data = JsonUtility.FromJson($"{{\"Rows\":{json}}}",selectedClass);

            Debug.Log(data);
            ScriptableObjectGenerator.CreateAssets(data);
        }

        private async Task<string> HttpGet(string u)
        {
            using var client = new HttpClient();
            return await client.GetStringAsync(u);
        }
    }
}