using UnityEngine;

namespace SoomgoRoomDecor
{
    public class PlacementValidator : MonoBehaviour
    {
        [SerializeField] private LayerMask obstacleMask;
        [SerializeField] private Vector3 overlapBoxHalfExtents = new Vector3(0.35f, 0.35f, 0.35f);
        [SerializeField] private float wallSnapDistance = 0.4f;

        public bool IsValid(Vector3 position, Quaternion rotation)
        {
            Collider[] overlaps = Physics.OverlapBox(position, overlapBoxHalfExtents, rotation, obstacleMask, QueryTriggerInteraction.Ignore);
            return overlaps.Length == 0;
        }

        public Vector3 TryWallSnap(Vector3 position)
        {
            Vector3[] directions = { Vector3.left, Vector3.right, Vector3.forward, Vector3.back };
            foreach (Vector3 dir in directions)
            {
                if (Physics.Raycast(position + Vector3.up * 0.5f, dir, out RaycastHit hit, wallSnapDistance))
                {
                    return hit.point - dir * 0.25f;
                }
            }
            return position;
        }
    }
}
