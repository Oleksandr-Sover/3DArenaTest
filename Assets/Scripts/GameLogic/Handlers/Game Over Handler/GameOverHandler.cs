using UnityEngine;

namespace GameLogic
{
    public class GameOverHandler : MonoBehaviour
    {
        [SerializeField]
        GameObject infoBar;
        [SerializeField]
        GameObject gameController;
        [SerializeField]
        GameObject resultMenu;
        [SerializeField]
        Data.PlayerData playerData;

        bool isGameOverSet = false;

        void Update()
        {
            if (playerData.Health <= 0 && !isGameOverSet)
            {
                SetGameOver();
                isGameOverSet = true;
            }
        }

        void SetGameOver()
        {
            infoBar.SetActive(false);
            gameController.SetActive(false);
            resultMenu.SetActive(true);

            PlayPauseHandler.Pause();
        }
    }
}