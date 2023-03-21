using UnityEngine;

namespace GameLogic
{
    public class BulletMovement : Movement, IBulletMovement
    {
        public void MoveBullet(Vector3 direction, float speed) => Move(direction, speed);
    }
}