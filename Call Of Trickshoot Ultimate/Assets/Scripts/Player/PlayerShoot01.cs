using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot01 : MonoBehaviour
{
    [SerializeField] private PlayerHandlerInput01 _playerHandlerInput01;
    [SerializeField] private Animator _weaponAnimator;
    [SerializeField] private Weapon _weaponCurrent;
    [SerializeField] private float _shoot;
    [SerializeField] private bool _arme1main, _arme2main, _canShoot;
    [SerializeField] private GameObject _arme1, _arme2;
    [SerializeField] private Transform _bulletParent;

    [SerializeField] private GameObject _panelArme;
    [SerializeField] private TextMeshProUGUI _textNomArme, _textChargeurArme;

    private void Start()
    {
        _panelArme.SetActive(true);
        SetWeaponCurrent(_arme1);
        _arme1main = true;
        _arme2main = false;
        VerifCanSHoot();
    }

    private void Update()
    {
        if (_shoot == 1)
        {
            if (_canShoot)
            {
                _weaponCurrent.Shoot(_bulletParent, _playerHandlerInput01.PlayerConfig.PlayerProfil.Pseudo);
                _textChargeurArme.text = _weaponCurrent.GetChargeurText();
            }
        }
    }

    public void SetShoot(float value)
    {
        _shoot = value;
    }

    public void SetWeaponCurrent(GameObject weapon)
    {
        _weaponCurrent = weapon.GetComponentInChildren<Weapon>();
        _textNomArme.text = _weaponCurrent.name;
        _textChargeurArme.text = _weaponCurrent.GetChargeurText();
    }

    public void TakeArme1()
    {
        Debug.Log("TakeArme1()");
        _arme2main = false;
        _arme1main = true;
        _arme2.SetActive(_arme2main);
        _arme1.SetActive(_arme1main);
        SetWeaponCurrent(_arme1);
    }

    public void TakeArme2()
    {
        Debug.Log("TakeArme2()");
        _arme1main = false;
        _arme2main = true;
        _arme1.SetActive(_arme1main);
        _arme2.SetActive(_arme2main);
        SetWeaponCurrent(_arme2);
    }

    public void SetParent(Transform bulletParent)
    {
        _bulletParent = bulletParent;
    }

    public GameObject Arme1 { get => _arme1; set => _arme1 = value; }
    public GameObject Arme2 { get => _arme2; set => _arme2 = value; }

    public void SetRecharge(bool value)
    {
        _weaponCurrent.SetRecharge(value);
    }

    private void VerifCanSHoot()
    {
        _canShoot = _weaponCurrent.CanShoot();
    }

    public void Recharge()
    {
        _weaponCurrent.Recharge();
        _textChargeurArme.text = _weaponCurrent.GetChargeurText();
    }

    public bool CanRecharge()
    {
        return _weaponCurrent.CanRecharge();
    }
}
