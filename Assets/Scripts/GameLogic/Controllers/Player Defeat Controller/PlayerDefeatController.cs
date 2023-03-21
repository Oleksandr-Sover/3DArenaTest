using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public abstract class PlayerDefeatController : MonoBehaviour, IPlayerDefeatController
    {
        public ISpawner Spawner { get; set; }
        public Data.PlayerData PlayerData { get; set; }
        public int EnemyDamage { get; set; }

        readonly string playerTag = "Player";

        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.collider.CompareTag(playerTag))
                HitPlayer();
            else
                HitOther();
        }

        void HitPlayer()
        {
            PlayerData.Health -= EnemyDamage;
            Spawner.Destroy(gameObject);
        }

        protected abstract void HitOther();
    }
}