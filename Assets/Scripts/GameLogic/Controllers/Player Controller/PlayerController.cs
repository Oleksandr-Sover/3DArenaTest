using UnityEngine;
using UnityEngine.InputSystem;

namespace GameLogic
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        Data.PlayerData PlayerData;

        PlayerInput playerInput;
        IPlayerMovement Movement;
        IInspection Inspection;

        Vector2 input;
        Vector2 zero = Vector2.zero;

        readonly string moveAction = "Move";
        readonly string lookAction = "Look";

        void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            Movement = GetComponent<IPlayerMovement>();
            Inspection = GetComponent<IInspection>();
        }

        void Update()
        {
            MovePlayer();
            LookPlayer();
        }

        void MovePlayer()
        {
            if (Movement.IsGrounded())
            {
                input = playerInput.actions[moveAction].ReadValue<Vector2>();

                if (input != zero)
                    Movement.MovePlayer(input, PlayerData.Speed, PlayerData.CamTransform);
            }
        }

        void LookPlayer()
        {
            input = playerInput.actions[lookAction].ReadValue<Vector2>();
            Inspection.Look(input, PlayerData.Sensitivity, PlayerData.CamTransform);
        }
    }
}