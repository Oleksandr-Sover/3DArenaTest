using UnityEngine;

namespace GameLogic
{
    public interface IGuidedBulletController
    {
        Transform PlayerTransform { get; set; }
        float BulletSpeed { get; set; }
        bool TargetVisible { get; set; }
    }
}