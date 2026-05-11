using UnityEngine;

namespace SoomgoRoomDecor
{
    public class PlacementGrid : MonoBehaviour
    {
        [SerializeField] private float gridSize = 0.5f;
        [SerializeField] private bool enableGridSnap = true;

        public Vector3 Snap(Vector3 worldPos)
        {
            if (!enableGridSnap) return worldPos;
            return new Vector3(
                Mathf.Round(worldPos.x / gridSize) * gridSize,
                worldPos.y,
                Mathf.Round(worldPos.z / gridSize) * gridSize
            );
        }

        public void SetGridEnabled(bool enabled) => enableGridSnap = enabled;
    }
}
