using UnityEngine;

namespace SoomgoRoomDecor
{
    public class UploadManager : MonoBehaviour
    {
        [SerializeField] private GameObject billboardPrefab;
        [SerializeField] private Transform furnitureRoot;

        public void CreateBillboardFromTexture(Texture2D texture)
        {
            if (texture == null || billboardPrefab == null) return;

            // MVP: alpha 기반 단순 배경 제거를 기대하며 PNG alpha를 그대로 사용.
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0f), 100f);
            GameObject obj = Instantiate(billboardPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, furnitureRoot);
            SpriteRenderer renderer = obj.GetComponentInChildren<SpriteRenderer>();
            if (renderer != null) renderer.sprite = sprite;
        }
    }
}
