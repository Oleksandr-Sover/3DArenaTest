using System;
using UnityEngine;

namespace Data
{
    public class PlayerData : MonoBehaviour
    {
        public Transform CamTransform { get => camTransform; set => camTransform = value; }
        [SerializeField]
        Transform camTransform;

        public int Health 
        { 
            get => health;
            set 
            { 
                if (value > 100)
                    health = 100;
                else
                    health = value; 
            } 
        }  
        [SerializeField]
        int health = 100;

        public int Power 
        { 
            get => power;
            set 
            { 
                if (value > 100)
                    power = 100;
                else
                    power = value; 
            } 
        }
        [SerializeField]
        int power = 50;

        public int MaxPower { get => maxPower; }
        int maxPower = 100;

        public float Speed { get => speed; }
        [SerializeField]
        float speed = 1;

        public float Sensitivity { get => sensitivity; }
        [SerializeField]
        float sensitivity = 1;

        public float BulletSpeed { get => bulletSpeed; }
        [SerializeField]
        float bulletSpeed = 10;

        public int PowerForBoss { get => powerForBoss; }
        [SerializeField]
        int powerForBoss = 50;

        public int PowerForKamikaze { get => powerForKamikaze; }
        [SerializeField]
        int powerForKamikaze = 15;

        public int PowerForRicochet { get => powerForRicochet; }
        [SerializeField]
        int powerForRicochet = 10;

        public int HealthForRicochet { get => Health / 2; }

        public float RicochetProbability
        { 
            get
            {
                if (Health != oldHealth && Health > 0)
                {
                    oldHealth = Health;
                    ricochetProbability = 10f / Health;
                    return ricochetProbability;
                }
                else
                    return ricochetProbability;
            }
        }

        int oldHealth = 0;
        float ricochetProbability;
    }
}