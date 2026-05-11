using UnityEngine;

namespace SoomgoRoomDecor
{
    public class InputManager : MonoBehaviour
    {
        public bool IsPointerDown => Input.GetMouseButton(0) || Input.touchCount > 0;

        public Vector2 PointerPosition
        {
            get
            {
                if (Input.touchCount > 0) return Input.GetTouch(0).position;
                return Input.mousePosition;
            }
        }

        public float MouseWheel => Input.mouseScrollDelta.y;

        public bool TryGetPinchDelta(out float delta)
        {
            delta = 0f;
            if (Input.touchCount < 2) return false;

            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);
            Vector2 prev0 = t0.position - t0.deltaPosition;
            Vector2 prev1 = t1.position - t1.deltaPosition;
            float prevDist = Vector2.Distance(prev0, prev1);
            float currDist = Vector2.Distance(t0.position, t1.position);
            delta = currDist - prevDist;
            return true;
        }
    }
}
