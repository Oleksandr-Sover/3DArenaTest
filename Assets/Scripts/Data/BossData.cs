using UnityEngine;

namespace Data
{
    public class BossData : MonoBehaviour
    {
        public int Damage { get => damage; }
        [SerializeField]
        int damage = 25;

        public float SqrMaxDistanceToPlayer { get => sqrMaxDistanceToPlayer; }
        float sqrMaxDistanceToPlayer;

        [SerializeField]
        float maxDistanceToPlayer = 2f;

        public float Speed { get => speed; }
        [SerializeField]
        float speed = 0.2f;

        public float BulletSpeed { get => bulletSpeed; }
        [SerializeField]
        float bulletSpeed = 6;

        public float RotationSpeed { get => rotationSpeed; }
        [SerializeField]
        float rotationSpeed = 4;

        public float MaxShotInterval { get => maxShotInterval; }
        [SerializeField]
        float maxShotInterval = 3;

        public float MinShotInterval { get => minShotInterval; }
        [SerializeField]
        float minShotInterval = 1;

        void Start()
        {
            sqrMaxDistanceToPlayer = maxDistanceToPlayer * maxDistanceToPlayer;
        }
    }
}