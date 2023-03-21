using UnityEngine;

namespace GameLogic
{
    public class PlayerMovement : CharacterMovement, IPlayerMovement
    {
        Vector3 direction = Vector3.zero;

        public void MovePlayer(Vector2 input, float speed, Transform camTr)
        {
            direction.x = input.x;
            direction.z = input.y;
            direction = direction.x * camTr.right + direction.z * camTr.forward;
            direction.y = 0;

            Move(direction, speed);
        }
    }
}