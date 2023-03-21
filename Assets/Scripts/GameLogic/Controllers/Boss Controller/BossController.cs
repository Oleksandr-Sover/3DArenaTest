using UnityEngine;

namespace GameLogic
{
    public class BossController : MonoBehaviour, IBossController
    {
        IBossMovement BossMovement;
        IBossWeapon BossWeapon;
        IRotatorToTarget RotatorToTarget;

        public ISpawner BulletSpawner { get; set; }
        public Transform PlayerTransform { get; set; }
        public Vector3 ArenaCenter { get; set; }
        public float Speed { get; set; }
        public float SqrMaxDistanceToPlayer { get; set; }
        public float SqrAreaRadius { get; set; }
        public float MaxShotInterval { get; set; }
        public float MinShotInterval { get; set; }
        public float RotationSpeed { get; set; }


        void Awake()
        {
            BossMovement = GetComponent<IBossMovement>();
            BossWeapon = GetComponentInChildren<IBossWeapon>();
            RotatorToTarget = GetComponent<IRotatorToTarget>();
        }

        void Update()
        {
            BossMovement.MoveBoss(PlayerTransform.position, ArenaCenter, Speed, SqrMaxDistanceToPlayer, SqrAreaRadius);
            BossWeapon.Shoot(BulletSpawner, PlayerTransform.position, MaxShotInterval, MinShotInterval);
            RotatorToTarget.Rotate(PlayerTransform, RotationSpeed);
        }
    }
}