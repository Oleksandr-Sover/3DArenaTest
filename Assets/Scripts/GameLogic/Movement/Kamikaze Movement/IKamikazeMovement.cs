using UnityEngine;

namespace GameLogic
{
    public interface IKamikazeMovement
    {
        void MoveKamikaze(Transform targetTransform, float attackSpeed, float upSpeed, float height, float hangTime);
        void SetStartValue();
        public bool IsAttack { get; }
    }
}