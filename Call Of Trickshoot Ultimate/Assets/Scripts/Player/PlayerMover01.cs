using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover01 : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private PlayerGroundCheck _playerGroundCheck;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animatorCamera;
    [SerializeField] float _speedCurrent, _speedWalk, _speedRun, _jumpHeight, _gravity;
    [SerializeField] private Vector3 _velocity, _move, _directionJump;

    [SerializeField] private Vector2 inputVector;
    [SerializeField] private bool _isWalk, _isRun, _isGrounded, _isJump, _isFall;
    [SerializeField] private float _run, _minToWalk, _minToRun;

    private void Update()
    {
        // Ground
        IsGrounded();
        // Jump
        IsJump();
        // Fall
        IsFall();
        _controller.Move(_velocity * Time.deltaTime);
    }

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    public void SetJump(float value)
    {
        if (value == 1)
        {
            _isJump = true;
        }
        else
        {
            _isJump = false;
        }
        _animatorCamera.SetBool("Jump", _isJump);
    }


    private void IsGrounded()
    {
        _isGrounded = _playerGroundCheck.GroundCheck;
        if (_isGrounded)
        {
            if(_isFall)
            _isFall = false;

            IfIsWalk();
            // Run
            IsRun();

            if(!_isWalk && !_isRun)
            {
                _speedCurrent = 0;
            }
            _move = transform.right * inputVector.x + transform.forward * inputVector.y;
            //_controller.Move(_move * _speedCurrent * Time.deltaTime);
            _velocity.x = _move.x * _speedCurrent;
            _velocity.z = _move.z * _speedCurrent;
        }
        _animatorCamera.SetBool("Fall", _isFall);
    }

    private void IfIsWalk()
    {
        if (!_isRun && (inputVector.x >= _minToWalk || inputVector.x <= -_minToWalk || inputVector.y >= _minToWalk || inputVector.y <= -_minToWalk))
        {

            _speedCurrent = _speedWalk;
            _isWalk = true;
        }
        else
        {
            _isWalk = false;
        }
        _animatorCamera.SetBool("Walk", _isWalk);
    }

    private void IsRun()
    {
        if (_run == 1 && (inputVector.x >= _minToRun || inputVector.x <= -_minToRun || inputVector.y >= _minToRun || inputVector.y <= -_minToRun))
        {
            _isRun = true;
            _speedCurrent = _speedRun;
        }
        else
        {
            _isRun = false;
        }
        _animatorCamera.SetBool("Run", _isRun);
    }

    public void SetRun(float value)
    {
        _run = value;
/*        if (value == 1 && inputVector.x >= _minToRun || inputVector.x <= -_minToRun || inputVector.y >= _minToRun || inputVector.y <= -_minToRun)
        {
            _isRun = true;
        }*/
    }

    private void IsJump()
    {
        if (_isJump && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            _velocity.x = _move.x * _speedCurrent * 2;
            _velocity.z = _move.z * _speedCurrent * 2;
        }
    }

    private void IsFall()
    {
        if (!_isGrounded)
        {
            _isFall = true;
        }

        if(_isFall)
        {
            _velocity.y += _gravity * Time.deltaTime;
        }
    }
}
