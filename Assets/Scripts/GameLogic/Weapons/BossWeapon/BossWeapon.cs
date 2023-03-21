using UnityEngine;

namespace GameLogic
{
    public class BossWeapon : MonoBehaviour, IBossWeapon
    {
        float timer;

        public void Shoot(ISpawner bulletSpawner, Vector3 targetPosition, float maxTime, float minTime)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            else
            {
                bulletSpawner.Create(transform.position);
                timer = Random.Range(maxTime, minTime);
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 0.08f);
        }
    }
}