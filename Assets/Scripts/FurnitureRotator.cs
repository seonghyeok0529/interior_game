using System.Collections;
using UnityEngine;

namespace SoomgoRoomDecor
{
    public class FurnitureRotator : MonoBehaviour
    {
        [SerializeField] private float rotationDuration = 0.15f;
        private Coroutine rotateRoutine;

        public void Rotate45()
        {
            float targetY = Mathf.Round((transform.eulerAngles.y + 45f) / 45f) * 45f;
            Quaternion target = Quaternion.Euler(0f, targetY, 0f);

            if (rotateRoutine != null) StopCoroutine(rotateRoutine);
            rotateRoutine = StartCoroutine(SmoothRotate(target));
        }

        private IEnumerator SmoothRotate(Quaternion target)
        {
            Quaternion start = transform.rotation;
            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime / rotationDuration;
                transform.rotation = Quaternion.Slerp(start, target, t);
                yield return null;
            }
            transform.rotation = target;
        }
    }
}
