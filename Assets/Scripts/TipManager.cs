using System.Collections.Generic;
using UnityEngine;

namespace SoomgoRoomDecor
{
    public class TipManager : MonoBehaviour
    {
        [SerializeField] private TipCardUI tipCardUI;
        [SerializeField] private List<string> tips = new()
        {
            "작은 방은 조명을 활용하면 넓어 보일 수 있습니다.",
            "러그를 추가하면 공간이 안정적으로 보일 수 있습니다.",
            "침대는 창문 방향에 따라 분위기가 달라질 수 있습니다.",
            "작은 공간은 수납 가구 활용이 중요합니다."
        };

        public void ShowRandomTip()
        {
            if (tips.Count == 0) return;
            tipCardUI.Show(tips[Random.Range(0, tips.Count)]);
        }
    }
}
