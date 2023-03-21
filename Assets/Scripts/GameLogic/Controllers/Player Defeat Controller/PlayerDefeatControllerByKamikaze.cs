
namespace GameLogic
{
    public class PlayerDefeatControllerByKamikaze : PlayerDefeatController
    {
        IKamikazeMovement KamikazeMovement;

        void Awake()
        {
            KamikazeMovement = GetComponent<IKamikazeMovement>();
        }

        protected override void HitOther()
        {
            if (KamikazeMovement.IsAttack)
                Spawner.Destroy(gameObject);
        }
    }
}