using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IRotatorToTarget
    {
        void Rotate(Transform target, float speed);
    }
}