using UnityEngine;

namespace GameLogic
{
    public class BossMovement : CharacterMovement, IBossMovement
    {
        IArenaCheck ArenaCheck;

        void Start()
        {
            ArenaCheck = new ArenaCheck();
        }

        public void MoveBoss(Vector3 playerPosition, Vector3 centerOfArena, float speed, float sqrMaxDistanceToPlayer, float sqrAreaRadius)
        {
            Vector3 distance = playerPosition - transform.position;
            float sqrDistance = distance.sqrMagnitude;

            if (sqrDistance > sqrMaxDistanceToPlayer)
            {
                MoveInDirection(distance, speed);
            }
            else if (sqrDistance < sqrMaxDistanceToPlayer)
            {
                if (ArenaCheck.IsInsideArena(transform.position, centerOfArena, sqrAreaRadius))
                {
                    MoveInDirection(-distance, speed);
                }
            }
        }

        void MoveInDirection(Vector3 distance, float speed)
        {
            Vector3 direction = distance.normalized;
            Move(direction, speed);
        }
    }
}