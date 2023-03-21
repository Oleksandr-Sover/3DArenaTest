using UnityEngine;

namespace GameLogic
{
    public class Inspection : MonoBehaviour, IInspection
    {
        Vector3 up = Vector3.up;
        Vector3 left = Vector3.left;
        Vector2 rotation = Vector3.zero;

        public void Look(Vector2 input, float sensitivity, Transform camTransform)
        {
            rotation.x += input.x * sensitivity;
            rotation.y += input.y * sensitivity;
            rotation.y = Mathf.Clamp(rotation.y, -70, 70);
            var xQuaternion = Quaternion.AngleAxis(rotation.x, up);
            var yQuaternion = Quaternion.AngleAxis(rotation.y, left);

            camTransform.localRotation = xQuaternion * yQuaternion;
        }
    }
}