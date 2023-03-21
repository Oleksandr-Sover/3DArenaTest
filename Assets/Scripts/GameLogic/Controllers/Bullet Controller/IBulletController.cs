using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IBulletController
    {
        Data.GeneralData GeneralData { get; set; }
        Data.PlayerData PlayerData { get; set; }
        IRicochetHandler RicochetHandler { get; set; }
        ISpawner BossSpawner { get; set; }
        ISpawner KamikazeSpawner { get; set; }
        ISpawner BulletSpawner { get; set; }
        Vector3 Direction { get; set; }
    }
}