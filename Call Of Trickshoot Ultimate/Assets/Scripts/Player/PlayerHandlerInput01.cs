using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using static UnityEngine.InputSystem.InputAction;

public class PlayerHandlerInput01 : MonoBehaviour
{
    [SerializeField] private PlayerConfiguration _playerConfig;
    [SerializeField] private PlayerMover01 _playerMover01;
    [SerializeField] private PlayerMoveCamera01 _playerMoveCamera01;
    [SerializeField] private PlayerShoot01 _playerShoot01;
    [SerializeField] private PlayerAction01 _playerAction01;
    [SerializeField] private PlayerEsclave _playerEsclave;

    [SerializeField] private ButtonPlayer _changeWeapon, _select;


    private MyPlayerInput controls;

    private void Awake()
    {
        controls = new MyPlayerInput();
    }

    private void Update()
    {
        // _changeWeapon.GestionButton();
        // _select.GestionButton();
    }

    public void InitializePlayer(PlayerConfiguration pc)
    {
        _playerConfig = pc;
        _playerConfig.Input.onActionTriggered += Input_onActionTriggered;
    }

    private void Input_onActionTriggered(CallbackContext obj)
    {
        // Mouvement
        if (obj.action.name == controls.Player.MoveLook.name)
        {
            OnMoveLook(obj);
        }
        if (obj.action.name == controls.Player.MoveDirection.name)
        {
            OnMoveDirection(obj);
        }
        if (obj.action.name == controls.Player.Run.name)
        {
            OnRun(obj);
        }
        if (obj.action.name == controls.Player.Jump.name)
        {
            OnJump(obj);
        }
        // Shoot
        if (obj.action.name == controls.Player.Shoot.name)
        {
            OnShoot(obj);
        }
        // Action
        // Viser
        if (obj.action.name == controls.Player.Viser.name)
        {
            OnViser(obj);
        }
        // Chaner Arme
        /*        _changeWeapon.GetValue(obj);
                if (_changeWeapon.IfOneOrDouble())
                {
                    _playerAction01.ChangeWeaponX();
                }*/
        if (obj.action.name == controls.Player.ChangeWeapon.name)
        {
            OnChangeWeapon(obj);
        }
        if (obj.action.name == controls.Player.Recharger.name)
        {
            OnRecharge(obj);
        }
        // Esclave
        if (obj.action.name == controls.Player.Esclave.name)
        {
            OnEsclave(obj);
        }

        // Select
        //_select.GetValue(obj);
        // Afficher Score
        if (obj.action.name == controls.Player.Select.name)
        {
            OnAfficherScore(obj);
        }
    }

    // Mouvement
    private void OnMoveLook(CallbackContext context)
    {
        if (_playerMoveCamera01 != null)
        {
            _playerMoveCamera01.SetInputVector(context.ReadValue<Vector2>());
        }
    }

    private void OnMoveDirection(CallbackContext context)
    {
        if (_playerMover01 != null)
        {
            _playerMover01.SetInputVector(context.ReadValue<Vector2>());
        }
    }

    private void OnRun(CallbackContext context)
    {
        if (_playerMover01 != null)
        {
            _playerMover01.SetRun(context.ReadValue<float>());
        }
    }

    private void OnJump(CallbackContext context)
    {
        if (_playerMover01 != null)
        {
            _playerMover01.SetJump(context.ReadValue<float>());
        }
    }

    // Shoot
    private void OnShoot(CallbackContext context)
    {
        if (_playerShoot01 != null)
        {
            _playerShoot01.SetShoot(context.ReadValue<float>());
        }
    }

    // Action
    private void OnViser(CallbackContext context)
    {
        if (_playerAction01 != null)
        {
            _playerAction01.SetViser(context.ReadValue<float>());
        }
    }
    private void OnChangeWeapon(CallbackContext context)
    {
        if (_playerAction01 != null)
        {
            _playerAction01.SetChangeWeapon(context.ReadValue<float>());
        }
    }
    private void OnRecharge(CallbackContext context)
    {
        if (_playerAction01 != null)
        {
            _playerAction01.SetRecharge(context.ReadValue<float>());
        }
    }
    private void OnAfficherScore(CallbackContext context)
    {
        if (_playerAction01 != null)
        {
            _playerAction01.SetAffcicherScore(context.ReadValue<float>());
        }
    }
    // Esclave
    public void OnEsclave(CallbackContext context)
    {
        if (_playerEsclave != null)
        {
            _playerEsclave.SetEsclave(context.ReadValue<float>());
        }
    }


    public PlayerConfiguration PlayerConfig { get => _playerConfig; set => _playerConfig = value; }
}
