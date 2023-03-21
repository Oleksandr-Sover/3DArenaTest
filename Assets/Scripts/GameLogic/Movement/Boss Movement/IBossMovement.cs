using UnityEngine;

namespace GameLogic
{
    public interface IBossMovement
    {
        void MoveBoss(Vector3 playerPosition, Vector3 centerOfArena, float speed, float sqrMaxDistanceToPlayer, float sqrAreaRadius);
    }
}