using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PlayPauseHandler
    {
        public static bool isPaused = false;

        public static void Play()
        {
            isPaused = false;
            Time.timeScale = 1;
        }

        public static void Pause()
        {
            isPaused = true;
            Time.timeScale = 0;
        }
    }
}