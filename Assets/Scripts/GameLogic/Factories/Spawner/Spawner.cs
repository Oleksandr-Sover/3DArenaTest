using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class Spawner : MonoBehaviour, ISpawner
    {
        [SerializeField]
        GameObject prefab;

        readonly IFactory<GameObject> Factory = new GameObjectFactory();

        public List<GameObject> Objects { get => Factory.Objects; }

        IObjectSetter ObjectSetter;

        void Awake()
        {
            ObjectSetter = GetComponent<IObjectSetter>();
        }

        public void Create(Vector3 position)
        {
            GameObject obj = Factory.Create(prefab);
            obj.transform.position = position;
            ObjectSetter.SetObjectValue(obj);
        }

        public void Destroy(GameObject obj) => Factory.Destroy(obj);
    }
}