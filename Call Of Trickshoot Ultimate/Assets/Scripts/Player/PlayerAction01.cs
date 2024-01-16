using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction01 : MonoBehaviour
{
    // SETUP
    [SerializeField] private GameParametreData _gameParametreData;
    [SerializeField] private PlayerShoot01 _playerShoot01;
    [SerializeField] private Animator _weaponAnimator;
    // VISER
    [SerializeField] private float _viser;
    // CHANGE WEAPON
    [SerializeField] private float _changeWeapon, _timerDesactiveAppui, _timerDesactiveAppuiMax;
    [SerializeField] private bool _range, _out, _appui, _desappui, _reappui, _desactiveAppuiState, _oneTape, _oneRelease, _doubleTap, _doubleRelease;
    // Recharger
    [SerializeField] private bool _recharger;
    // SCORE
    [SerializeField] private float _afficherScoreF;
    [SerializeField] private bool _afficherScore1, _afficherScore2;
    // UI 
    [SerializeField] private PlayerUI _playerUI;


    private void Update()
    {
        Viser();
        ChangeWeapon();
    }

    private void AnnuleByTime()
    {
        if (_appui)
        {
            if (_timerDesactiveAppui <= _timerDesactiveAppuiMax && _timerDesactiveAppui > 0)
            {
                _timerDesactiveAppui -= Time.deltaTime;
            }
            else
            {
                _appui = false;
                _desappui = false;
            }
        }
    }
    // VISER
    private void Viser()
    {
        if (_viser > 0)
        {
            _weaponAnimator.SetBool("Viser", true);
            _weaponAnimator.SetFloat("ViserF", _viser);
        }
        else
        {
            _weaponAnimator.SetBool("Viser", false);
            _weaponAnimator.SetFloat("ViserF", _viser);
        }
    }
    public void SetViser(float value)
    {
        _viser = value;
    }
    // CHANGE WEAPON
    private void ChangeWeapon()
    {
        // One Tape
        if (_changeWeapon == 1 && !_range && !_out && !_oneTape && !_oneRelease && !_doubleTap && !_doubleRelease)
        {
            Debug.Log("Doit Ranger l'arme");
            _oneTape = true;
            SetRange(true);
        }
        else if (_changeWeapon == 1 && !_range && _out && !_oneTape && !_oneRelease && !_doubleTap && !_doubleRelease)
        {
            Debug.Log("Doit Ranger l'autre arme");
            SetOut(false);
            SetRange(true);
        }
        // One Release
        if (_changeWeapon == 0 && _range && !_out && _oneTape && !_oneRelease && !_doubleTap && !_doubleRelease)
        {
            _oneRelease = true;
        }
        // Double Tape
        if (_changeWeapon == 1 && _range && !_out && _oneTape && _oneRelease && !_doubleTap && !_doubleRelease)
        {
            Debug.Log("Doit Ranger la meme arme");
            _doubleTap = true;
            SetRange(false);
        }
        // Double Release
        if (_changeWeapon == 0 && _range && !_out && _oneTape && !_oneRelease && !_doubleTap && !_doubleRelease)
        {
            _doubleRelease = true;
            DesactiveAllTape();
        }
    }
    public void ChangeWeaponState()
    {
        if (_playerShoot01.Arme1.activeSelf)
        {
            _playerShoot01.TakeArme2();
        }
        else if (_playerShoot01.Arme2.activeSelf)
        {
            _playerShoot01.TakeArme1();
        }
    }
    public void SetChangeWeapon(float value)
    {
        _changeWeapon = value;
    }
    public void SetDesactiveAppuiState(bool value)
    {
        _desactiveAppuiState = value;
    }
    public void SetDesappui(bool value)
    {
        _desappui = value;
    }
    public void SetRangeState(bool value)
    {
        _range = value;
    }
    public void SetOutState(bool value)
    {
        _out = value;
    }
    public void SetRange(bool value)
    {
        _range = value;
        _weaponAnimator.SetBool("Range", value);
    }
    public void SetOut(bool value)
    {
        _out = value;
        _weaponAnimator.SetBool("Out", value);
    }
    public void DesactiveAllTape()
    {
        _oneTape = false;
        _oneRelease = false;
        _doubleTap = false;
        _doubleRelease = false;
    }

    // Rechargement
    public void SetRecharge(float value)
    {
        if (_playerShoot01.CanRecharge())
        {
            // Debug.Log("PLayer Action 01 Set Recharge");
            _recharger = true;
            _playerShoot01.SetRecharge(_recharger);
        }
        else
        {
            // Debug.Log("Can Recharge = False");
        }
    }
    public void RechargeFini()
    {
        _playerShoot01.Recharge();
    }

    // AFFICHER SCORE
    public void SetAffcicherScore(float value)
    {
        _afficherScoreF = value;
        AfficherScore();
    }
    private void AfficherScore()
    {
        if (_afficherScoreF == 1 && !_playerUI.PanelScore.activeSelf && !_afficherScore1 && !_afficherScore2)
        {
            Debug.Log("Ici Afficher prendre les valeurs des joueur et les afficher");
            _playerUI.PanelScore.SetActive(true);
            if (_gameParametreData.IfTeam())
            {
                _playerUI.PanelScoreTeam.SetActive(true);
            }
            else
            {
                _playerUI.PanelScoreNoTeam.SetActive(true);
            }
            _afficherScore1 = true;
        }
        if (_afficherScoreF == 0 & _playerUI.PanelScore.activeSelf && _afficherScore1 && !_afficherScore2)
        {
            _afficherScore2 = true;
        }
        if (_afficherScoreF == 1 && _playerUI.PanelScore.activeSelf && _afficherScore1 && _afficherScore2)
        {
            if (_gameParametreData.IfTeam())
            {
                _playerUI.PanelScoreTeam.SetActive(false);
            }
            else
            {
                _playerUI.PanelScoreNoTeam.SetActive(false);
            }
            _afficherScore1 = false;
            _playerUI.PanelScore.SetActive(false);
        }
        if(_afficherScoreF == 0 && !_playerUI.PanelScore.activeSelf && !_afficherScore1 && _afficherScore2)
        {
            _afficherScore2 = false;
        }
    }
}
