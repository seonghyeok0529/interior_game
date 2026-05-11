using TMPro;
using UnityEngine;

namespace SoomgoRoomDecor
{
    public class TipCardUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text tipText;
        [SerializeField] private GameObject panel;

        public void Show(string message)
        {
            panel.SetActive(true);
            tipText.text = message;
        }

        public void Hide() => panel.SetActive(false);
    }
}
