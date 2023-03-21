using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ResultMenuHandler : MonoBehaviour
    {
        [SerializeField]
        Data.GeneralData generalData;
        
        TextMeshProUGUI scoreTextMesh;

        void OnEnable()
        {
            scoreTextMesh = GetComponent<TextMeshProUGUI>();
            SetScore();
        }

        void SetScore()
        {
            int score = generalData.Score;
            string scoreText = score.ToString();
            scoreTextMesh.text = scoreText;
        }
    }
}