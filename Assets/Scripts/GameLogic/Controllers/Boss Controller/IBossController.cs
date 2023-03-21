using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IBossController
    {
        ISpawner BulletSpawner { get; set; }
        Transform PlayerTransform { get; set; }
        Vector3 ArenaCenter { get; set; }
        float Speed { get; set; }
        float SqrMaxDistanceToPlayer { get; set; }
        float SqrAreaRadius { get; set; }
        float MaxShotInterval { get; set; }
        float MinShotInterval { get; set; }
        float RotationSpeed { get; set; }
    }
}