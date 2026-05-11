using UnityEngine;

namespace SoomgoRoomDecor
{
    public class BillboardObject : MonoBehaviour
    {
        [SerializeField] private Transform visual;

        private void LateUpdate()
        {
            if (Camera.main == null || visual == null) return;
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0f;
            visual.forward = forward.normalized;
        }

        public void SetScale(float scale) => transform.localScale = Vector3.one * Mathf.Max(0.1f, scale);
    }
}
