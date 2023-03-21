using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PlayerBulletSetter : MonoBehaviour, IObjectSetter
    {
        [SerializeField]
        Data.GeneralData generalData;
        [SerializeField]
        Data.PlayerData playerData;

        IRicochetHandler RicochetHandler { get => ricochetHandler; }
        [SerializeField]
        RicochetHandler ricochetHandler;

        ISpawner BossSpawner { get => bossSpawner; }
        [SerializeField]
        Spawner bossSpawner;

        ISpawner KamikazeSpawner { get => kamikazeSpawner; }
        [SerializeField]
        Spawner kamikazeSpawner;

        ISpawner BulletSpawner { get => bulletSpawner; }
        [SerializeField]
        Spawner bulletSpawner;

        IBulletController BulletController;

        public void SetObjectValue(GameObject obj)
        {
            BulletController = obj.GetComponent<IBulletController>();
            BulletController.PlayerData = playerData;
            BulletController.GeneralData = generalData;
            BulletController.RicochetHandler = RicochetHandler;
            BulletController.BossSpawner = BossSpawner;
            BulletController.KamikazeSpawner = KamikazeSpawner;
            BulletController.BulletSpawner = BulletSpawner;
            BulletController.Direction = playerData.CamTransform.forward;
        }
    }
}