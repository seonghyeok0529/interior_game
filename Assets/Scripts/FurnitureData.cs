using UnityEngine;

namespace SoomgoRoomDecor
{
    public enum FurnitureCategory
    {
        Bed,
        Desk,
        Chair,
        Sofa,
        Light,
        Plant,
        Rug,
        Storage,
        Frame,
        Bookshelf,
        Uploaded
    }

    [CreateAssetMenu(fileName = "FurnitureData", menuName = "SoomgoRoomDecor/Furniture Data")]
    public class FurnitureData : ScriptableObject
    {
        public string id;
        public string displayName;
        public FurnitureCategory category;
        public GameObject prefab;
        public Sprite icon;
        public Vector3 defaultSize = Vector3.one;
    }
}
