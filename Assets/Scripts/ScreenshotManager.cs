using System.Collections;
using System.IO;
using UnityEngine;

namespace SoomgoRoomDecor
{
    public class ScreenshotManager : MonoBehaviour
    {
        public void SaveScreenshot() => StartCoroutine(CaptureRoutine());

        private IEnumerator CaptureRoutine()
        {
            yield return new WaitForEndOfFrame();
            Texture2D tex = ScreenCapture.CaptureScreenshotAsTexture();
            byte[] png = tex.EncodeToPNG();
            string filename = $"room_{System.DateTime.Now:yyyyMMdd_HHmmss}.png";
            string path = Path.Combine(Application.persistentDataPath, filename);
            File.WriteAllBytes(path, png);
            Debug.Log($"Screenshot saved: {path}");
            Destroy(tex);
        }
    }
}
