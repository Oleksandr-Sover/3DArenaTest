using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class ActiveEnemyGroupHandler : MonoBehaviour, IActiveEnemyGroupHandler
    {
        public ISpawner[] EnmemySpawners { get => enmemySpawners; set => enmemySpawners = (Spawner[])value; }
        [SerializeField]
        Spawner[] enmemySpawners;

        public List<GameObject> GroupOfCurrentEnemies { get => groupOfCurrentEnemies; private set => groupOfCurrentEnemies = value; }
        List<GameObject> groupOfCurrentEnemies = new List<GameObject>();

        int[] lengthOfEnemyLists;

        void Start()
        {
            CreateLengthOfEnemyLists();
        }

        void Update()
        {
            UpdateListCfCurrentEnemies();
        }

        void CreateLengthOfEnemyLists()
        {
            lengthOfEnemyLists = new int[EnmemySpawners.Length];
            int length = lengthOfEnemyLists.Length;

            for (int i = 0; i < length; i++)
            {
                lengthOfEnemyLists[i] = 0;
            }
        }

        void UpdateListCfCurrentEnemies()
        {
            int length = EnmemySpawners.Length;

            for (int i = 0; i < length; i++)
            {
                if (EnmemySpawners[i].Objects.Count != lengthOfEnemyLists[i])
                {
                    lengthOfEnemyLists[i] = EnmemySpawners[i].Objects.Count;
                    CreateGroupOfCurrentEnemies();
                    break;
                }
            }
        }

        void CreateGroupOfCurrentEnemies()
        {
            groupOfCurrentEnemies.Clear();

            foreach (var spawner in EnmemySpawners)
            {
                groupOfCurrentEnemies.AddRange(spawner.Objects);
            }

        }
    }
}