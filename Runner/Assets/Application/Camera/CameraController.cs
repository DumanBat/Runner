using UnityEngine;

namespace Application.App.CameraControls
{
    public class CameraController : MonoBehaviour
    {
        private Camera _currentCamera;

        public Camera GetCamera() => _currentCamera ?? Camera.main;

        public void SetCamera(Camera camera, Transform target)
        {
            _currentCamera = camera;
            var cameraFollow = _currentCamera.GetComponent<CameraFollow>();
            cameraFollow.Init(target);
        }
    }
}