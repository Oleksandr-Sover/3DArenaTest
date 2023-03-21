using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IRicochetHandler
    {
        (bool, Vector3) DefineRicochet(GameObject currentEnemy, Transform bulletTransform);
    }
}