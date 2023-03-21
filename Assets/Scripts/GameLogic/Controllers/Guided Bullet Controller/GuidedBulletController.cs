using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class GuidedBulletController : MonoBehaviour, IGuidedBulletController
    {
        IBulletMovement BulletMovement;

        public Transform PlayerTransform { get; set; }
        public float BulletSpeed { get ; set; }
        public bool TargetVisible { get; set; }

        Vector3 direction;

        void Awake()
        {
            BulletMovement = GetComponent<IBulletMovement>();
        }

        void OnEnable()
        {
            TargetVisible = true;
        }

        void Update()
        {
            if (TargetVisible)
                direction = (PlayerTransform.position - transform.position).normalized;

            BulletMovement.MoveBullet(direction, BulletSpeed);
        }
    }
}