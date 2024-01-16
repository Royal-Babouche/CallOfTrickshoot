using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEsclave : MonoBehaviour
{
    [SerializeField] private PlayerRayCast _playerRayCast;
    [SerializeField] private float _esclave;
    [SerializeField] private GameObject _esclaveGo;
    [SerializeField] private MoveEsclave _moveEsclave;

    private void Update()
    {
        if (_esclave == 1)
        {
            if (_playerRayCast.HitPointWorld != Vector3.zero)
            {
                _moveEsclave.SetDestination(_playerRayCast.HitPointWorld);
            }
        }
    }

    public void SetEsclave(float value)
    {
        _esclave = value;
    }

    public void SetActiveGo(bool value)
    {
        _esclaveGo.SetActive(value);
    }
}
