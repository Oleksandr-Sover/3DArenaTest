using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IActiveEnemyGroupHandler
    {
        ISpawner[] EnmemySpawners { get; }
        List<GameObject> GroupOfCurrentEnemies { get; }
    }
}