using UnityEngine;

namespace GameLogic
{
    public class KamikazeMovement : CharacterMovement, IKamikazeMovement
    {
        Vector3 attackDirection;
        Vector3 up = Vector3.up;

        float timer;

        public bool IsAttack { get => !setAttackDirection; }

        bool moveUp = true;
        bool setTimer = true;
        bool setAttackDirection = true;

        public void MoveKamikaze(Transform targetTransform, float attackSpeed, float upSpeed, float height, float hangTime)
        {
            if (setTimer)
            {
                timer = hangTime;
                setTimer = false;
            }
            else if (moveUp)
                moveUp = MoveUp(upSpeed, height);
            else if (setAttackDirection)
            {
                attackDirection = SetAttackDirection(targetTransform);
                setAttackDirection = false;
            }
            else
                Attack(attackDirection, attackSpeed);
        }

        bool MoveUp(float upSpeed, float height)
        {
            if (timer > 0)
            {
                if (transform.position.y < height)
                    Move(up, upSpeed);
                else
                {
                    Move(up, -Data.GeneralData.Gravity);
                    timer -= Time.deltaTime;
                }
                return true;
            }
            else
                return false;
        }

        Vector3 SetAttackDirection(Transform transformTarget) => (transformTarget.position - transform.position).normalized;

        void Attack(Vector3 direction, float speed)
        {
            Move(up, -Data.GeneralData.Gravity);
            Move(direction, speed);
        }

        public void SetStartValue()
        {
            moveUp = true;
            setTimer = true;
            setAttackDirection = true;
        }
    }
}