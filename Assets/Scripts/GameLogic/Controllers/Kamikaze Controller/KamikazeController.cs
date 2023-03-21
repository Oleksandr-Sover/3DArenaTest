using UnityEngine;

namespace GameLogic
{
    public class KamikazeController : MonoBehaviour, IKamikazeController
    {
        IKamikazeMovement KamikazeMovement;

        public Transform PlayerTransform { get; set; }
        public float AttackSpeed { get; set; }
        public float UpSpeed { get; set; }
        public float Height { get; set; }
        public float MaxHangTime { get; set; }
        public float MinHangTime { get; set; }

        float hangTime;

        void Awake()
        {
            KamikazeMovement = GetComponent<IKamikazeMovement>();
        }

        void Start()
        {
            hangTime = Random.Range(MinHangTime, MaxHangTime);
        }

        void Update()
        {
            KamikazeMovement.MoveKamikaze(PlayerTransform, AttackSpeed, UpSpeed, Height, hangTime);
        }
    }
}