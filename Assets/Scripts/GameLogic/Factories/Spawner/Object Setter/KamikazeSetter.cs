using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class KamikazeSetter : MonoBehaviour, IObjectSetter
    {
        [SerializeField]
        Data.GeneralData generalData;
        [SerializeField]
        Data.KamikazeData kamikazeData;
        [SerializeField]
        Data.PlayerData playerData;

        ISpawner Spawner;
        IKamikazeController KamikazeController;
        IPlayerDefeatController PlayerDefeatController;
        IKamikazeMovement KamikazeMovement;

        void Awake()
        {
            Spawner = GetComponent<ISpawner>();
        }

        public void SetObjectValue(GameObject kamikaze)
        {
            KamikazeMovement = kamikaze.GetComponent<IKamikazeMovement>();
            KamikazeMovement.SetStartValue();
            PlayerDefeatController = kamikaze.GetComponent<IPlayerDefeatController>();
            PlayerDefeatController.Spawner = Spawner;
            PlayerDefeatController.EnemyDamage = kamikazeData.Damage;
            PlayerDefeatController.PlayerData = playerData;
            KamikazeController = kamikaze.GetComponent<IKamikazeController>();
            KamikazeController.PlayerTransform = generalData.PlayerTransform;
            KamikazeController.AttackSpeed = kamikazeData.AttackSpeed;
            KamikazeController.UpSpeed = kamikazeData.UpSpeed;
            KamikazeController.Height = kamikazeData.Height;
            KamikazeController.MaxHangTime = kamikazeData.MaxHangTime;
            KamikazeController.MinHangTime = kamikazeData.MinHangTime;
        }
    }
}