using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class CharacterMovement : Movement
    {
        Vector3 gravityMovement = Vector3.zero;

        void Update()
        {
            UseGravity();
        }

        void UseGravity()
        {
            if (!IsGrounded())
            {
                gravityMovement.y = Data.GeneralData.Gravity * Time.deltaTime;
                controller.Move(gravityMovement);
            }
        }
    }
}