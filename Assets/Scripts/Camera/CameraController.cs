using UnityEngine;
using UnityEngine.InputSystem;
namespace TopDown.CameraControl
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float displacementMultiplier = 0.15f;
        private float zPosition = -10;

        private void Update()
        {
            if (Mouse.current == null) return;

            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, Mathf.Abs(transform.position.z)));

            Vector3 cameraDisplacement = (mousePosition - playerTransform.position) * displacementMultiplier;

            Vector3 finalCameraPosition = playerTransform.position + cameraDisplacement;
            finalCameraPosition.z = zPosition;
            transform.position = finalCameraPosition;
        }
    }
}
