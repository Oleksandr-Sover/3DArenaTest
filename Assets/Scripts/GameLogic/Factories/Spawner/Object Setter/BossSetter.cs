using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class BossSetter : MonoBehaviour, IObjectSetter
    {
        ISpawner BulletSpawner { get => bulletSpawner; }
        [SerializeField]
        Spawner bulletSpawner;

        [SerializeField]
        Data.GeneralData generalData;
        [SerializeField]
        Data.BossData bossData;

        IBossController BossController;

        public void SetObjectValue(GameObject boss)
        {
            BossController = boss.GetComponent<IBossController>();
            BossController.BulletSpawner = BulletSpawner;
            BossController.PlayerTransform = generalData.PlayerTransform;
            BossController.ArenaCenter = generalData.ArenaCenter;
            BossController.Speed = bossData.Speed;
            BossController.SqrMaxDistanceToPlayer = bossData.SqrMaxDistanceToPlayer;
            BossController.SqrAreaRadius = generalData.SqrAreaRadius;
            BossController.MaxShotInterval = bossData.MaxShotInterval;
            BossController.MinShotInterval = bossData.MinShotInterval;
            BossController.RotationSpeed = bossData.RotationSpeed;
        }
    }
}