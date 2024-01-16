using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerHandle : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    public void OnMoveDirection(CallbackContext context)
    {
        _playerMover.SetInputVector(context.ReadValue<Vector2>());
    }
}
