using TMPro;
using UnityEngine;

namespace UI
{
    public class PauseHandler : MonoBehaviour
    {
        [SerializeField]
        GameObject gameController;

        TextMeshProUGUI buttonTextMesh;

        readonly string pause = "Pause";
        readonly string resume = "Resume";

        void Awake()
        {
            buttonTextMesh = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void PauseResume()
        {
            if (GameLogic.PlayPauseHandler.isPaused)
                Play();
            else
                Pause();
        }

        void Pause()
        { 
            gameController.SetActive(false);
            buttonTextMesh.text = resume;
            GameLogic.PlayPauseHandler.Pause();
        }

        void Play() 
        {
            gameController.SetActive(true);
            buttonTextMesh.text = pause;
            GameLogic.PlayPauseHandler.Play();
        }    
    }
}