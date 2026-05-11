using System.Collections.Generic;
using UnityEngine;

namespace SoomgoRoomDecor
{
    public class FurnitureManager : MonoBehaviour
    {
        [SerializeField] private Transform furnitureRoot;
        [SerializeField] private Camera sceneCamera;
        [SerializeField] private PlacementGrid placementGrid;
        [SerializeField] private PlacementValidator placementValidator;

        private readonly List<GameObject> placedFurniture = new();
        public GameObject Selected { get; private set; }

        public GameObject PlaceFurniture(FurnitureData data, Vector3 position)
        {
            GameObject go = Instantiate(data.prefab, position, Quaternion.identity, furnitureRoot);
            go.name = $"{data.displayName}_{data.id}";
            var drag = go.GetComponent<FurnitureDraggable>() ?? go.AddComponent<FurnitureDraggable>();
            drag.Init(sceneCamera, placementGrid, placementValidator);
            go.AddComponent<FurnitureRotator>();
            placedFurniture.Add(go);
            Select(go);
            return go;
        }

        public void Select(GameObject target) => Selected = target;
        public void Deselect() => Selected = null;

        public void DeleteSelected()
        {
            if (Selected == null) return;
            placedFurniture.Remove(Selected);
            Destroy(Selected);
            Selected = null;
        }

        public void RotateSelected() => Selected?.GetComponent<FurnitureRotator>()?.Rotate45();

        public void DuplicateSelected()
        {
            if (Selected == null) return;
            Vector3 pos = Selected.transform.position + new Vector3(0.5f, 0f, 0.5f);
            GameObject clone = Instantiate(Selected, pos, Selected.transform.rotation, furnitureRoot);
            placedFurniture.Add(clone);
            Select(clone);
        }

        public void ClearAll()
        {
            for (int i = placedFurniture.Count - 1; i >= 0; i--) Destroy(placedFurniture[i]);
            placedFurniture.Clear();
            Selected = null;
        }
    }
}
