using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PlayerTeleportController : MonoBehaviour
    {
        IArenaCheck ArenaCheck = new ArenaCheck();

        ISpawner BossSpawner { get => bossSpawner; }
        [SerializeField]
        Spawner bossSpawner;

        ISpawner KamikazeSpawner { get => kamikazeSpawner; }
        [SerializeField]
        Spawner kamikazeSpawner;

        ISpawner GuidedBulletSpawner { get => guidedBulletSpawner; }
        [SerializeField]
        Spawner guidedBulletSpawner;

        [SerializeField]
        Data.GeneralData generalData;

        [SerializeField]
        Transform playerTransform;

        Vector3 teleportPosition;
        Vector3 middlePosition;
        
        List<float> enemyXPosition = new List<float>();
        List<float> enemyZPosition = new List<float>();

        bool teleport;

        void Update()
        {
            teleport = !ArenaCheck.IsInsideArena(playerTransform.position, generalData.ArenaCenter, generalData.SqrAreaRadius);

            if (teleport)
            {
                Teleport();
                HidePlayerFromBullets();
            }
        }

        void Teleport()
        {
            middlePosition = GetMiddlePositionOfEnemies();
            teleportPosition = GetTeleportPosition(middlePosition);
            playerTransform.position = teleportPosition; 
        }

        void HidePlayerFromBullets()
        {
            foreach (var bullet in GuidedBulletSpawner.Objects)
                bullet.GetComponent<IGuidedBulletController>().TargetVisible = false;
        }

        Vector3 GetTeleportPosition(Vector3 middlePosition)
        {
            Vector3 adjustCenter = generalData.ArenaCenter;
            adjustCenter.y = middlePosition.y;
            Vector3 invertedDirection = -(middlePosition - adjustCenter).normalized;
            return invertedDirection * generalData.TeleportRadius;
        }

        Vector3 GetMiddlePositionOfEnemies()
        {
            enemyXPosition.Clear();
            enemyZPosition.Clear();

            FillListsOfPosition(BossSpawner.Objects);
            FillListsOfPosition(KamikazeSpawner.Objects);

            float maxX = FindMaxValue(enemyXPosition);
            float minX = FindMinValue(enemyXPosition);
            float maxZ = FindMaxValue(enemyZPosition);
            float minZ = FindMinValue(enemyZPosition);

            Vector3 middlePosition;

            middlePosition.x = GetAverageValue(maxX, minX);
            middlePosition.z = GetAverageValue(maxZ, minZ);
            middlePosition.y = generalData.StartYEnemyPosition;

            return middlePosition;
        }

        void FillListsOfPosition(List<GameObject> objects)
        {
            foreach (var obj in objects)
            {
                enemyXPosition.Add(obj.transform.position.x);
                enemyZPosition.Add(obj.transform.position.z);
            }
        }

        float FindMaxValue(List<float> values)
        {
            float max = 0;

            foreach (var value in values)
            {
                if (max == 0)
                    max = value;
                else if (value > max)
                    max = value;
            }
            return max;
        }

        float FindMinValue(List<float> values)
        {
            float min = 0;

            foreach (var value in values)
            {
                if (min == 0)
                    min = value;
                else if (value < min)
                    min = value;
            }
            return min;
        }

        float GetAverageValue(float max, float min) => (max + min) / 2;

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(teleportPosition, 0.2f);
            Gizmos.DrawLine(teleportPosition, middlePosition);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(middlePosition, 0.1f);
        }
    }
}