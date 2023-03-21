using UnityEngine;

namespace GameLogic
{
    public interface IInspection
    {
        void Look(Vector2 input, float sensitivity, Transform camTransform);
    }
}