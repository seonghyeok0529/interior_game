# SoomgoRoomDecor MVP 구성 가이드

## 포함된 핵심 스크립트
- GameManager, RoomManager, FurnitureManager
- FurnitureData(ScriptableObject), FurnitureDraggable, FurnitureRotator
- PlacementGrid, PlacementValidator
- CameraController, InputManager
- UploadManager, BillboardObject
- ScreenshotManager
- TipManager, TipCardUI

## Unity 에디터 연결 순서
1. `RoomEditor.unity` 씬 생성 후 아래 오브젝트 구성:
   - Isometric Camera
   - Directional Light
   - RoomRoot / FurnitureRoot / Managers
   - UI Canvas (TopBar, BottomFurniturePanel, FloatingToolbar, StylePanel, RoomSelectPanel, TipPanel)
2. `Managers` 하위에 각 Manager 스크립트 부착 후 SerializeField 연결.
3. Room 프리팹 6종(Studio/Bedroom/Living/Office/Small/LShape)과 Furniture 프리팹 카탈로그 연결.
4. Furniture 프리팹에는 Collider 부착 (드래그 Raycast 대상).
5. Floating Toolbar 버튼을 `FurnitureManager.RotateSelected/DeleteSelected/DuplicateSelected`에 연결.
6. Save 버튼을 `ScreenshotManager.SaveScreenshot`, Reset 버튼을 `GameManager.ResetRoom`에 연결.

## 모바일 MVP 메모
- 업로드는 네이티브 파일 피커 플러그인 연동 전제(현재는 Texture2D 입력 API 제공).
- 배경 제거는 PNG 알파 채널 기반 워크플로우를 우선 지원.
- 완전 자동 배경 제거는 차기 단계(온디바이스/서버)에서 확장.
