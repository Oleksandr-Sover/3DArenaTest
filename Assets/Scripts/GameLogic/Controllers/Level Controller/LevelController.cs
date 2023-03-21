using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class LevelController : MonoBehaviour
    {
        ISpawner BossSpawner { get =>  bossSpawner; }
        [SerializeField]
        Spawner bossSpawner;

        ISpawner KamikazeSpawner { get => kamikazeSpawner; }
        [SerializeField]
        Spawner kamikazeSpawner;

        [SerializeField]
        Data.GeneralData generalData;

        float timer;
        float time = 0;

        void Update()
        {
            GetEnemyGenerationTime(generalData.MaxEnemyGenerationTime, generalData.MinEnemyGenerationTime, generalData.DeltaEnemyGenerationTime);
            GenerateEnemies(generalData.ArenaRadius, generalData.StartYEnemyPosition, generalData.BossSpawnChance, time);
        }

        void GetEnemyGenerationTime(float maxTime, float minTime, float deltaTime)
        {
            if (time <= 0)
                time = maxTime;
            else if (time <= minTime)
                time = minTime;
            else
                time -= deltaTime;
        }    

        void GenerateEnemies(float arenaRadius, float startYPosition, float bossSpawnChance, float generationTime)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            else
            {
                timer = generationTime;
                Vector3 position = GetEnemyPosition(arenaRadius, startYPosition);
                SetEnemy(position, bossSpawnChance);
            }
        }

        Vector3 GetEnemyPosition(float arenaRadius, float startYPosition)
        {
            Vector2 randCirclePosition = Random.insideUnitCircle;
            randCirclePosition.x *= arenaRadius;
            randCirclePosition.y *= arenaRadius;
            return new Vector3(randCirclePosition.x, startYPosition, randCirclePosition.y);
        }

        void SetEnemy(Vector3 position, float bossSpawnChance)
        {
            float randEnemy = Random.value;

            if (randEnemy > bossSpawnChance)
                KamikazeSpawner.Create(position);
            else
                BossSpawner.Create(position);
        }
    }
}