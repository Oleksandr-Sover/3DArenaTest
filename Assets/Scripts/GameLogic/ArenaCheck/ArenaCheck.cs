using UnityEngine;

namespace GameLogic
{
    public class ArenaCheck: IArenaCheck
    {
        public bool IsInsideArena(Vector3 position, Vector3 centerOfArena, float sqrAreaRadius)
        {
            Vector3 arenaCenter = centerOfArena;
            arenaCenter.y = position.y;

            Vector3 distanceToArenaCenter = position - arenaCenter;
            float sqrDistance = distanceToArenaCenter.sqrMagnitude;

            if (sqrDistance < sqrAreaRadius)
                return true;
            else
                return false;
        }
    }
}