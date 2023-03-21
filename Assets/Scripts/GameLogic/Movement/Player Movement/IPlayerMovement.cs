using UnityEngine;

namespace GameLogic
{
    public interface IPlayerMovement
    {
        void MovePlayer(Vector2 input, float speed, Transform camTr);
        bool IsGrounded();
    }
}