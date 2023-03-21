using UnityEngine;

namespace Data
{
    public class KamikazeData : MonoBehaviour
    {
        public int Damage { get => damage; }
        [SerializeField]
        int damage = 15;

        public float UpSpeed { get => upSpeed; }
        [SerializeField]
        float upSpeed = 4;

        public float AttackSpeed { get => attackSpeed; }
        [SerializeField]
        float attackSpeed = 6;

        public float Height { get =>  height; }
        [SerializeField]
        float height = 1;

        public float MaxHangTime { get => maxHangTime; }
        [SerializeField]
        float maxHangTime = 4;

        public float MinHangTime { get => minHangTime; }
        [SerializeField]
        float minHangTime = 1;
    }
}