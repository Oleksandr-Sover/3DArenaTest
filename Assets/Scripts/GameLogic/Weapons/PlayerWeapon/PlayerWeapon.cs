using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PlayerWeapon : MonoBehaviour
    {
        ISpawner BulletSpawner { get => bulletSpawner; }
        [SerializeField]
        Spawner bulletSpawner;

        public void Fire()
        {
            BulletSpawner.Create(transform.position);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.05f);
        }
    }
}