using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCamera01 : MonoBehaviour
{
    [SerializeField] private Transform _playerTr, _rotationTr, _cameraTr, _posWeapon;
    [SerializeField] private Vector2 _mouseSensitivity, _inputVector;
    [SerializeField] private float _xRotation, _distPosWeapon, _anglePosWeaon, _radius;
    [SerializeField] private Vector3 _newPosWeaon;

    public void SetInputVector(Vector2 direction)
    {
        _inputVector = direction;
    }

    private void Update()
    {
        RotateV2();
    }

    private void RotateV1()
    {
        float mouseX = _inputVector.x * _mouseSensitivity.x * Time.deltaTime;
        float mouseY = _inputVector.y * _mouseSensitivity.y * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _cameraTr.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerTr.Rotate(Vector3.up * mouseX);


        _newPosWeaon = new Vector3();
        _newPosWeaon.x = _cameraTr.position.x + (_distPosWeapon * Mathf.Cos(_anglePosWeaon / (180f / Mathf.PI)));
        _newPosWeaon.y = _cameraTr.position.y + (_distPosWeapon * Mathf.Tan(_anglePosWeaon / (180f / Mathf.PI)));
        _newPosWeaon.z = _cameraTr.position.z + (_distPosWeapon * Mathf.Sin(_anglePosWeaon / (180f / Mathf.PI)));
        //_posWeapon.position = _newPosWeaon;
    }

    private void RotateV2()
    {
        float mouseX = _inputVector.x * _mouseSensitivity.x * Time.deltaTime;
        float mouseY = _inputVector.y * _mouseSensitivity.y * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _rotationTr.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerTr.Rotate(Vector3.up * mouseX);
    }

}
