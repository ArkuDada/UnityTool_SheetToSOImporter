using Unity.Plastic.Newtonsoft.Json;

namespace Editor.SheetTool
{
    [System.Serializable]
    public class SheetData
    {
        [JsonProperty]
        public SheetRow[] Rows;
    }
    
    [System.Serializable]
    public class SheetRow
    {
        [JsonProperty]
        public string Name;

        [JsonProperty]
        public int Hp;

        [JsonProperty]
        public int Attack;

        [JsonProperty]
        public int Defense;
    }
}