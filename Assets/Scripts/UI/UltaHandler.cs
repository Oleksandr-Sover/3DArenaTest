using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UltaHandler : MonoBehaviour
    {
        [SerializeField]
        Data.PlayerData playerData;
        [SerializeField]
        GameObject ulataButton;

        int oldPower;

        void Update()
        {
            if (oldPower != playerData.Power)
            {
                oldPower = playerData.Power;

                if (playerData.Power >= 100)
                    ulataButton.SetActive(true);
                else
                    ulataButton.SetActive(false);
            }
        }
    }
}