using UnityEngine;

namespace GameLogic
{
    public interface IArenaCheck
    {
        bool IsInsideArena(Vector3 position, Vector3 centerOfArena, float sqrAreaRadius);
    }
}