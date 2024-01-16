using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cadance
{
    [SerializeField] private bool _canShoot;
    [SerializeField] private float _cadanceCurrent, _cadanceMax;

    public void InitCadance()
    {
        _cadanceCurrent = _cadanceMax;
        _canShoot = true;
    }

    public void GestionCadance()
    {
        if (_cadanceCurrent < _cadanceMax)
        {
            _cadanceCurrent += Time.deltaTime;
        }
        else
        {
            _cadanceCurrent = _cadanceMax;
            _canShoot = true;
        }
    }

    public void Shoot()
    {
        _canShoot = false;
        _cadanceCurrent = 0;
    }

    public bool CanShoot { get => _canShoot; set => _canShoot = value; }
}
