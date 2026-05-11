using System;
using System.Collections.Generic;
using UnityEngine;

namespace SoomgoRoomDecor
{
    public enum RoomType { Studio, Bedroom, LivingRoom, Office, Small, LShape }

    [Serializable]
    public struct RoomPrefabEntry
    {
        public RoomType roomType;
        public GameObject prefab;
    }

    public class RoomManager : MonoBehaviour
    {
        [SerializeField] private Transform roomRoot;
        [SerializeField] private List<RoomPrefabEntry> roomPrefabs;
        [SerializeField] private Light directionalLight;

        private GameObject currentRoom;

        public void SelectRoom(RoomType type)
        {
            if (currentRoom != null) Destroy(currentRoom);
            var entry = roomPrefabs.Find(x => x.roomType == type);
            if (entry.prefab != null) currentRoom = Instantiate(entry.prefab, roomRoot);
        }

        public void ApplyWallColor(Color color)
        {
            if (currentRoom == null) return;
            foreach (Renderer renderer in currentRoom.GetComponentsInChildren<Renderer>())
            {
                if (renderer.gameObject.name.ToLower().Contains("wall")) renderer.material.color = color;
            }
        }

        public void ApplyFloorMaterial(Material mat)
        {
            if (currentRoom == null || mat == null) return;
            foreach (Renderer renderer in currentRoom.GetComponentsInChildren<Renderer>())
            {
                if (renderer.gameObject.name.ToLower().Contains("floor")) renderer.material = mat;
            }
        }

        public void ApplyLightingTone(Color color, float intensity)
        {
            directionalLight.color = color;
            directionalLight.intensity = intensity;
        }
    }
}
