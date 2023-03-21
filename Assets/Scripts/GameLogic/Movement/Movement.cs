using UnityEngine;

namespace GameLogic
{
    public class Movement : MonoBehaviour
    {
        protected CharacterController controller;

        void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        public bool IsGrounded() => controller.isGrounded;

        public void Move(Vector3 direction, float speed)
        {
            controller.Move(speed * Time.deltaTime * direction);
        }
    }
}