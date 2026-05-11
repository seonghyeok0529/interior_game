using UnityEngine;

namespace SoomgoRoomDecor
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private RoomManager roomManager;
        [SerializeField] private FurnitureManager furnitureManager;
        [SerializeField] private TipManager tipManager;

        private void Start()
        {
            roomManager.SelectRoom(RoomType.Studio);
            tipManager.ShowRandomTip();
        }

        public void ResetRoom()
        {
            furnitureManager.ClearAll();
            roomManager.SelectRoom(RoomType.Studio);
        }
    }
}
