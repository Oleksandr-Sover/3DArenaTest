using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IKamikazeController
    {
        Transform PlayerTransform { get; set; }
        float AttackSpeed { get; set; }
        float UpSpeed { get; set; }
        float Height { get; set; }
        float MaxHangTime { get; set; }
        float MinHangTime { get; set; }
    }
}