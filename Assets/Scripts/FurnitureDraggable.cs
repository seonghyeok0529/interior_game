using UnityEngine;

namespace SoomgoRoomDecor
{
    [RequireComponent(typeof(Collider))]
    public class FurnitureDraggable : MonoBehaviour
    {
        [SerializeField] private float followSpeed = 15f;
        private bool isDragging;
        private Camera cam;
        private PlacementGrid grid;
        private PlacementValidator validator;
        private Vector3 targetPos;

        public void Init(Camera sceneCamera, PlacementGrid placementGrid, PlacementValidator placementValidator)
        {
            cam = sceneCamera;
            grid = placementGrid;
            validator = placementValidator;
        }

        private void Update()
        {
            if (!isDragging) return;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);
        }

        public void BeginDrag() => isDragging = true;
        public void EndDrag() => isDragging = false;

        public void DragToScreenPosition(Vector2 pointerPos)
        {
            Ray ray = cam.ScreenPointToRay(pointerPos);
            Plane floorPlane = new Plane(Vector3.up, Vector3.zero);
            if (!floorPlane.Raycast(ray, out float enter)) return;

            Vector3 point = ray.GetPoint(enter);
            point = grid.Snap(point);
            point = validator.TryWallSnap(point);

            if (validator.IsValid(point, transform.rotation))
            {
                targetPos = new Vector3(point.x, 0f, point.z);
            }
        }
    }
}
