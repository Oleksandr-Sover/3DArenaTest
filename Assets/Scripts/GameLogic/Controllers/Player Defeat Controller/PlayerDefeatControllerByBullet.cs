using UnityEngine;

namespace GameLogic
{
    public class PlayerDefeatControllerByBullet : PlayerDefeatController
    {
        protected override void HitOther() => Spawner.Destroy(gameObject);
    }
}