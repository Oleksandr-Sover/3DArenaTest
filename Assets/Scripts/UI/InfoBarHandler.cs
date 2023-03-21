using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InfoBarHandler : MonoBehaviour
    {
        [SerializeField]
        Data.GeneralData generalData;
        [SerializeField]
        Data.PlayerData playerData;
        [SerializeField]
        Slider healthSlider;
        [SerializeField]
        Slider powerSlider;
        [SerializeField]
        TextMeshProUGUI scoreTextMesh;

        string scoreText;

        int score;
        int health;
        int power;

        void Start()
        {
            SetStartScore();
            SetHealth();
            SetPower();
        }

        void Update()
        {
            SetScore();
            SetHealth();
            SetPower();
        }

        void SetStartScore()
        {
            score = generalData.Score;
            scoreText = score.ToString();
            scoreTextMesh.text = scoreText;
        }

        void SetScore()
        {
            if (score != generalData.Score)
            {
                score = generalData.Score;
                scoreText = score.ToString();
                scoreTextMesh.text = scoreText;
            }
        }

        void SetHealth()
        {
            if (health != playerData.Health)
            {
                health = playerData.Health;
                healthSlider.value = health;
            }
        }

        void SetPower()
        {
            if (power != playerData.Power)
            {
                power = playerData.Power;
                powerSlider.value = power;
            }
        }
    }
}