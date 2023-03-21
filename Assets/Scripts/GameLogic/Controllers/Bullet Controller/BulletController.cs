using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

namespace GameLogic
{
    public class BulletController : MonoBehaviour, IBulletController
    {
        IBulletMovement BulletMovement;

        public Data.GeneralData GeneralData { get; set; }
        public Data.PlayerData PlayerData { get; set; }
        public IRicochetHandler RicochetHandler { get; set; }
        public ISpawner BossSpawner { get; set; }
        public ISpawner KamikazeSpawner { get; set; }
        public ISpawner BulletSpawner { get; set; }
        public Vector3 Direction { get; set; }

        readonly string bossTag = "Boss";
        readonly string kamikazeTag = "Kamikaze";

        int ricochetNumber = 0;

        bool isRicochet = false;

        void Awake()
        {
            BulletMovement = GetComponent<IBulletMovement>();
        }

        void OnEnable()
        {
            ricochetNumber = 0;
            isRicochet = false;
        }

        void Update()
        {
            BulletMovement.MoveBullet(Direction, PlayerData.BulletSpeed);
        }

        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.collider.CompareTag(bossTag))
            {
                BossSpawner.Destroy(hit.gameObject);
                (isRicochet, Direction) = HandleRicochet(hit.gameObject);
                UpdateStates(1, PlayerData.PowerForBoss, PlayerData.PowerForRicochet, PlayerData.HealthForRicochet, isRicochet);
            }
            else if (hit.collider.CompareTag(kamikazeTag))
            {
                KamikazeSpawner.Destroy(hit.gameObject);
                (isRicochet, Direction) = HandleRicochet(hit.gameObject);
                UpdateStates(1, PlayerData.PowerForKamikaze, PlayerData.PowerForRicochet, PlayerData.HealthForRicochet, isRicochet);
            }
            else
                BulletSpawner.Destroy(gameObject);
        }

        (bool, Vector3) HandleRicochet(GameObject hitEnemy)
        {
            bool isRicochet;
            Vector3 direction;

            (isRicochet, direction) = RicochetHandler.DefineRicochet(hitEnemy, transform);

            if (!isRicochet) 
                BulletSpawner.Destroy(gameObject);

            return (isRicochet, direction);
        }

        void UpdateStates(int deltaScore, int deltaPower, int deltaRicochetPower, int deltaHealth, bool isRicochet)
        {
            if (isRicochet) 
                ricochetNumber++;

            if (ricochetNumber > 1)
            {
                float randValue = Random.value;

                if (randValue > 0.5)
                    PlayerData.Health += deltaHealth;
                else
                    PlayerData.Power += deltaRicochetPower;
            }
            else
                PlayerData.Power += deltaPower;

            GeneralData.Score += deltaScore;
        }
    }
}