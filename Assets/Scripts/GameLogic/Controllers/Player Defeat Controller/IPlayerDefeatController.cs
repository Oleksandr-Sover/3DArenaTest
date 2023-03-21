
namespace GameLogic
{
    public interface IPlayerDefeatController
    {
        ISpawner Spawner { get; set; }
        Data.PlayerData PlayerData { get; set; }
        int EnemyDamage { get; set; }
    }
}