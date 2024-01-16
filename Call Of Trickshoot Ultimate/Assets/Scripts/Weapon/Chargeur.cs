using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Chargeur
{
    [SerializeField] private bool _canShoot, _canRecharge;
    [SerializeField] private float _nbBulletCurent, _nbBulletChargeurMax, _nbChargeur, _nbBulletTotal;

    public void InitChargeur()
    {
        _nbBulletCurent = _nbBulletChargeurMax;
        _nbBulletTotal = _nbBulletChargeurMax * _nbChargeur;
        VerifCanShoot();
        _canRecharge = false;
    }

    public void Shoot()
    {
        _nbBulletCurent--;

        if(_nbBulletCurent == 0)
        {
            _canShoot = false;
        }

        if(_nbBulletCurent < _nbBulletChargeurMax && _nbChargeur > 0)
        {
            _canRecharge = true;
        }
    }
    public bool CanShoot { get => _canShoot; set => _canShoot = value; }

    private void VerifCanShoot()
    {
        if (_nbChargeur > 0)
        {
            if (_nbBulletCurent > 0)
            {
                _canShoot = true;
            }
        }
        else
        {
            _canShoot = false;
        }
    }

    public void Recharge()
    {
        float reste = _nbBulletChargeurMax - _nbBulletCurent;
        Debug.Log("Reste2 = " + reste);

        if (_nbBulletCurent + _nbBulletTotal >= _nbBulletChargeurMax)
        {
            _nbBulletTotal -= reste;
            _nbBulletCurent = _nbBulletChargeurMax;
        }
        else
        {
            _nbBulletCurent += _nbBulletTotal;
            _nbBulletTotal = 0;
        }

        if (_nbChargeur > 0)
        {
            if (_nbBulletTotal <= (_nbChargeur - 1) * _nbBulletChargeurMax)
            {
                _nbChargeur--;
            }
        }
        else
        {
            Debug.Log("Plus que 0 Chargeur");
        }

        _canRecharge = false;
        _canShoot = true;
    }

    public bool CanRecharge()
    {
        return _canRecharge;
    }

    public string GetChargeurText()
    {
        return _nbBulletCurent + "/" + _nbBulletChargeurMax + "/" + _nbChargeur + "/" + _nbBulletTotal;
    }

    public bool VerifDoitRechargerPourTirer()
    {
        bool verif = false;

        if(_nbBulletCurent == 0 && _nbBulletTotal > 0)
        {
            verif = true;
        }

        return verif;
    }
}
