using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class BulletFlightZoneController : MonoBehaviour
    {
        ISpawner GuidedBulletSpawner { get => guidedBulletSpawner; }
        [SerializeField]
        Spawner guidedBulletSpawner;

        ISpawner PlayerBulletSpawner { get => playerBulletSpawner; }
        [SerializeField]
        Spawner playerBulletSpawner;

        readonly string guidedBulletTag = "GuidedBullet";
        readonly string playerBulletTag = "PlayerBullet";

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(guidedBulletTag))
                GuidedBulletSpawner.Destroy(other.gameObject);
            else if (other.CompareTag(playerBulletTag))
                PlayerBulletSpawner.Destroy(other.gameObject);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(Vector3.zero, transform.localScale.x / 2);
        }
    }
}