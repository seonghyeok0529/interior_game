using UnityEngine;

namespace SoomgoRoomDecor
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float rotateSpeed = 60f;
        [SerializeField] private float zoomSpeed = 5f;
        [SerializeField] private float minZoom = 4f;
        [SerializeField] private float maxZoom = 12f;
        [SerializeField] private InputManager inputManager;

        private Camera cam;

        private void Awake()
        {
            cam = GetComponent<Camera>();
            transform.rotation = Quaternion.Euler(35f, 45f, 0f);
        }

        private void Update()
        {
            float scroll = inputManager.MouseWheel;
            if (Mathf.Abs(scroll) > 0.01f) cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - scroll * zoomSpeed * Time.deltaTime * 30f, minZoom, maxZoom);

            if (inputManager.TryGetPinchDelta(out float pinchDelta))
            {
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - pinchDelta * zoomSpeed * Time.deltaTime * 0.03f, minZoom, maxZoom);
            }

            if (Input.GetMouseButton(1)) transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime);
            if (Input.touchCount == 2)
            {
                Touch t0 = Input.GetTouch(0);
                Touch t1 = Input.GetTouch(1);
                float twist = (t0.deltaPosition.x + t1.deltaPosition.x) * 0.02f;
                transform.RotateAround(target.position, Vector3.up, twist * rotateSpeed * Time.deltaTime);
            }
        }
    }
}
