using UnityEngine;

namespace Editor.SheetTool
{
    [CreateAssetMenu(menuName = "Create SheetRowAsset", fileName = "SheetRowAsset", order = 0)]
    public class SheetRowAsset : ScriptableObject
    {
        public string Name;
        public int HP;
        public int Attack;
        public int Defense;
    }
}