using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class GuidedBulletSetter : MonoBehaviour, IObjectSetter
    {
        [SerializeField]
        Data.GeneralData generalData;
        [SerializeField]
        Data.BossData bossData;
        [SerializeField]
        Data.PlayerData playerData;

        ISpawner Spawner;
        IGuidedBulletController BulletController;
        IPlayerDefeatController PlayerDefeatController;

        void Awake()
        {
            Spawner = GetComponent<ISpawner>();
        }

        public void SetObjectValue(GameObject bullet)
        {
            PlayerDefeatController = bullet.GetComponent<IPlayerDefeatController>();
            PlayerDefeatController.Spawner = Spawner;
            PlayerDefeatController.EnemyDamage = bossData.Damage;
            PlayerDefeatController.PlayerData = playerData;
            BulletController = bullet.GetComponent<IGuidedBulletController>();
            BulletController.PlayerTransform = generalData.PlayerTransform;
            BulletController.BulletSpeed = bossData.BulletSpeed;
        }
    }
}