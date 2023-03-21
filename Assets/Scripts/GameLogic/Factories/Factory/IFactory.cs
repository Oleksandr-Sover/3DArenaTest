using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IFactory<T> where T : Object
    {
        public List<T> Objects { get; }
        public T Create(T original);
        public void Destroy(T objectToDestroy);
    }
}