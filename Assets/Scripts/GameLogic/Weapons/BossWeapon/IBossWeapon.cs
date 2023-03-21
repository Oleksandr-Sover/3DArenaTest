using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IBossWeapon
    {
        void Shoot(ISpawner bulletSpawner, Vector3 targetPosition, float maxTime, float minTime);
    }
}