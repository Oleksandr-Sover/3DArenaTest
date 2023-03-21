using UnityEngine;

namespace Data
{
    public class GeneralData : MonoBehaviour
    {
        public Vector3 PlayerPosition { get => playerTransform.position; }
        public Transform PlayerTransform { get => playerTransform; }
        [SerializeField]
        Transform playerTransform;

        public Vector3 ArenaCenter { get => arenaCenter; private set => arenaCenter = value; }
        Vector3 arenaCenter;
        [SerializeField]
        Transform arenaTransform;

        public int Score { get => score; set => score = value; }
        [SerializeField]
        int score = 0;

        public static float Gravity { get => _gravity; }
        static float _gravity;
        [SerializeField]
        float gravity = -9.81f;

        public float SqrAreaRadius { get => sqrArenaRadius; private set => sqrArenaRadius = value; }
        float sqrArenaRadius;

        public float ArenaRadius { get => arenaRadius; }
        [SerializeField]
        float arenaRadius = 9.5f;

        public float StartYEnemyPosition { get => startYEnemyPosition; }
        [SerializeField]
        float startYEnemyPosition = 0.3f;

        public float BossSpawnChance { get => bossSpawnChance; }
        [SerializeField, Range(0, 1)]
        float bossSpawnChance = 0.25f;

        public float MaxEnemyGenerationTime { get => maxEnemyGenerationTime; }
        [SerializeField]
        float maxEnemyGenerationTime = 5;

        public float MinEnemyGenerationTime { get => minEnemyGenerationTime; }
        [SerializeField]
        float minEnemyGenerationTime = 2;

        public float DeltaEnemyGenerationTime { get => deltaEnemyGenerationTime; }
        [SerializeField]
        float deltaEnemyGenerationTime = 1;

        public float TeleportRadius { get => teleportRadius; }
        float teleportRadius;

        void Start()
        {
            sqrArenaRadius = arenaRadius * arenaRadius;
            arenaCenter = arenaTransform.position;
            arenaCenter.y = 0;
            _gravity = gravity;
            teleportRadius = arenaRadius * 0.9f;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(arenaCenter, arenaRadius);
        }
    }
}