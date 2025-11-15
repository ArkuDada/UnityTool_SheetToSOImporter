using UnityEditor;
using UnityEngine;

namespace Editor.SheetTool
{
    public static class ScriptableObjectGenerator
    {
        public static void CreateAssets(object data)
        {
            SheetData sheetData = data as SheetData;
            if (sheetData == null)
            {
                Debug.LogError("Data is not of type SheetData");
                return;
            }
            
            foreach (var row in sheetData.Rows)
            {
                CreateScriptableObject(row);
            }
        }

        private static void CreateScriptableObject(SheetRow row)
        {
            var assetPath = $"Assets/Resources/SheetRowAssets/{row.Name}.asset";
            var existingAsset = AssetDatabase.LoadAssetAtPath<SheetRowAsset>(assetPath);
            
            SheetRowAsset asset;
            if (existingAsset != null)
            {
                asset = existingAsset;
                Debug.Log($"Updating existing asset: {row.Name}");
            }
            else
            {
                asset = ScriptableObject.CreateInstance<SheetRowAsset>();
                Debug.Log($"Creating new asset: {row.Name}");
            }
            
            asset.Name = row.Name;
            asset.HP = row.HP;
            asset.Attack = row.Attack;
            asset.Defense = row.Defense;
            
            if (existingAsset == null)
            {
                // Ensure the directory exists
                var directory = System.IO.Path.GetDirectoryName(assetPath);
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
            
                AssetDatabase.CreateAsset(asset, assetPath);
            }
            
            EditorUtility.SetDirty(asset);
        }
    }
}