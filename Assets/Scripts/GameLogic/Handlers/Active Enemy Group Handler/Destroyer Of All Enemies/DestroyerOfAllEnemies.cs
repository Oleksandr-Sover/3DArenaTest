using UnityEngine;

namespace GameLogic
{
    public class DestroyerOfAllEnemies : MonoBehaviour, IDestroyerOfAllEnemies
    {
        [SerializeField]
        Data.GeneralData generalData;
        [SerializeField]
        Data.PlayerData playerData;

        IActiveEnemyGroupHandler ActiveEnemyGroupHandler;

        int numberOfDestroyedEnemies;

        void Awake()
        {
            ActiveEnemyGroupHandler = GetComponent<IActiveEnemyGroupHandler>();
        }

        public void DestroyAllEnemy()
        {
            numberOfDestroyedEnemies = 0;

            foreach (var enemySpawner in ActiveEnemyGroupHandler.EnmemySpawners)
            {
                if (enemySpawner.Objects.Count > 0) 
                {
                    do
                    {
                        enemySpawner.Destroy(enemySpawner.Objects[0]);
                        numberOfDestroyedEnemies++;
                    }
                    while (enemySpawner.Objects.Count > 0);                
                }
            }
            SetData();
        }

        void SetData()
        {
            playerData.Power = 0;
            generalData.Score += numberOfDestroyedEnemies;
        }
    }
}