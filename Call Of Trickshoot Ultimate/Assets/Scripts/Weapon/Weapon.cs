using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private PlayerInGame _playerInGame;
    [SerializeField] private string _name;
    [SerializeField] private Transform _player, _posSpwanBullet;

    [SerializeField] private Chargeur _chargeur;
    [SerializeField] private Cadance _cadance;
    [SerializeField] private float _forceShoot;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private ArrayList _munitions;
    [SerializeField] private GameObject _munitionLibre;

    [SerializeField] private bool _recharge;
    [SerializeField] private Animator _animator;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioShoot;

    private void Awake()
    {
        _chargeur.InitChargeur();
        _cadance.InitCadance();
        _munitions = new ArrayList();
    }

    private void Update()
    {
        _cadance.GestionCadance();
    }

    public void Shoot(Transform munitionParent, string playerName)
    {
        // Debug.Log("Shoot");
        if (_cadance.CanShoot)
        {
            if (_chargeur.CanShoot)
            {

                if (_munitions.Count == 0 && VerifieSiMunitionLibre() == false)
                {
                    SpawnMunition(munitionParent, playerName);
                }
                // Prend la première Munition Libre
                else
                {
                    PrendMunitionLibre();
                }
                Shoot();
            }
            else if (_chargeur.VerifDoitRechargerPourTirer())
            {
                Debug.Log("Faire en sorte que l'arme se recharge seul?");   
                //_chargeur.Recharge();
            }
        }
    }

    private bool VerifieSiMunitionLibre()
    {
        bool value = false;
        foreach (GameObject goMunition in _munitions)
        {
            if (value == false)
            {
                if (goMunition.activeSelf == false)
                {
                    _munitionLibre = goMunition;
                    value = true;
                }
            }
        }
        return value;
    }
    public void SpawnMunition(Transform munitionParent, string playerName)
    {
        GameObject munition = Instantiate(_bulletPrefab, _posSpwanBullet.position, _posSpwanBullet.rotation, munitionParent);

        munition.name = playerName + "_" + transform.name + "_Munition_" + _munitions.Count;
        munition.GetComponent<Bullet>().SetPlayerInGame(_playerInGame);
        _munitionLibre = munition;
        _munitions.Add(_munitionLibre);
    }
    private void PrendMunitionLibre()
    {
        _munitionLibre.SetActive(true);
    }

    private void Shoot()
    {
        // Debug.Log("Shoot");
        _munitionLibre.transform.position = _posSpwanBullet.position;
        _munitionLibre.transform.rotation = _posSpwanBullet.rotation;
        _munitionLibre.GetComponent<Bullet>().InitBullet(_forceShoot);
        JouSonTire();
        _cadance.Shoot();
        _chargeur.Shoot();
    }

    public void SetRecharge(bool value)
    {
        _recharge = value;
        _animator.SetBool("Recharge", _recharge);
    }

    // Son
    private void JouSonTire()
    {
        _audioSource.PlayOneShot(_audioShoot);
    }

    public void SetPlayerInGame(PlayerInGame playeringame)
    {
        _playerInGame = playeringame;
    }

    public bool CanShoot()
    {
        return _chargeur.CanShoot;
    }

    public void Recharge()
    {
        _chargeur.Recharge();
    }

    public bool CanRecharge()
    {
        return _chargeur.CanRecharge();
    }

    public string GetChargeurText()
    {
        return _chargeur.GetChargeurText();
    }
}
