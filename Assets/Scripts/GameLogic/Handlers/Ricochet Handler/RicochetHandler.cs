using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class RicochetHandler : MonoBehaviour, IRicochetHandler
    {
        [SerializeField]
        Data.PlayerData playerData;

        IActiveEnemyGroupHandler ActiveEnemyGroupHandler { get => activeEnemyGroupHandler; }
        [SerializeField]
        ActiveEnemyGroupHandler activeEnemyGroupHandler;

        Vector3 ricochetDirection;

        public (bool, Vector3) DefineRicochet(GameObject currentEnemy, Transform bulletTransform)
        {
            int count = ActiveEnemyGroupHandler.GroupOfCurrentEnemies.Count;

            if (count > 1)
            {
                bool isRicochet = IsRicochet();

                if (isRicochet)
                {
                    GameObject ricochetEnemy = FindNearestEnemy(ActiveEnemyGroupHandler.GroupOfCurrentEnemies, currentEnemy);
                    ricochetDirection = (ricochetEnemy.transform.position - bulletTransform.position).normalized;

                    return (isRicochet, ricochetDirection);
                }
                else
                    return (false, bulletTransform.forward);
            }
            else
                return (false, bulletTransform.forward);
        }

        bool IsRicochet()
        {
            float ricochet = Random.value;

            if (ricochet < playerData.RicochetProbability)
                return true;
            else
                return false;
        }

        GameObject FindNearestEnemy(List<GameObject> enemies, GameObject currentEnemy)
        {
            GameObject nearestEnemy = null;
            float sqrMinDistance = 10000;
            float sqrDistance;

            foreach (var enemy in enemies)
            {
                if (enemy != currentEnemy)
                {
                    sqrDistance = (enemy.transform.position - transform.position).sqrMagnitude;

                    if (sqrDistance < sqrMinDistance)
                    {
                        sqrMinDistance = sqrDistance;
                        nearestEnemy = enemy;
                    }
                }
            }
            return nearestEnemy;
        }
    }
}