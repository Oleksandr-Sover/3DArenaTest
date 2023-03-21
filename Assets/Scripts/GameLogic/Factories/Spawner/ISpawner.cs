using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface ISpawner
    {
        public List<GameObject> Objects { get; }
        void Create(Vector3 position);
        void Destroy(GameObject obj);
    }
}