using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    // Setup
    [SerializeField] private PlayerProfilInGame _playerProfilInGame;
    // Reticule Hitmarker
    [SerializeField] private GameObject _goReticule, _goHitMarker;
    [SerializeField] private Image _imageReticule, _imageHitMarker;
    [SerializeField] private Color32 _colorReticule, _colorHitmarker, _colorHitMarkerKill;
    [SerializeField] private bool _afficherHitMarker;
    [SerializeField] private float _timeHit, _timeHitMax, _colorAvalue, _coefTimeHitA;
    // Score
    [SerializeField] private GameObject _panelScore, _panelScoreTeam, _panelScoreNoTeam;
    [SerializeField] private ScrollRect _scrollNoTeam, _scrollTeam1, _scrollTeam2;
    [SerializeField] private GameObject _prefabTextScore;

    private void Start()
    {
        _imageReticule.color = _colorReticule;
        _imageHitMarker.color = _colorHitmarker;
    }

    private void Update()
    {
        // GestionHitByTime();
        GestionHitByAlpha2();
    }

    public void SetActiveReticule(bool value)
    {
        _goReticule.SetActive(value);
    }

    public void SetActiveHitMarker(bool value)
    {
        _goHitMarker.SetActive(value);
    }

    private void GestionHitByTime()
    {
        if (_timeHit <= _timeHitMax)
        {
            _timeHit -= Time.deltaTime;
        }
        if (_timeHit <= 0)
        {
            _timeHit = _timeHitMax;
            _goHitMarker.SetActive(false);
        }
    }

    private void GestionHitByAlpha()
    {
        if (_playerProfilInGame.PlayerInGame.HitMarker)
        {
            _afficherHitMarker = true;
            if (!_goHitMarker.activeSelf)
            {
                _goHitMarker.SetActive(true);
            }
            if (_imageHitMarker.color.a != 255)
            {
                _imageHitMarker.color = _colorHitmarker - new Color(0, 0, 0, 255);
            }
            _imageHitMarker.color = new Color(_colorHitmarker.r, _colorHitmarker.g, _colorHitmarker.b, 255 - Time.deltaTime * _coefTimeHitA);
            _playerProfilInGame.PlayerInGame.SetHit(false);
        }

        if (_afficherHitMarker)
        {
            _imageHitMarker.color = _colorHitmarker - new Color(0, 0, 0, 255 - (Time.deltaTime * _coefTimeHitA));

            if (_imageHitMarker.color.a <= 0)
            {
                _afficherHitMarker = false;
                _goHitMarker.SetActive(false);
            }
        }
    }

    private void GestionHitByAlpha2()
    {
        if(_playerProfilInGame.PlayerInGame.HitMarker)
        {
            if (!_goHitMarker.activeSelf)
            {
                _goHitMarker.SetActive(true);
            }
            Debug.Log("_imageHitMarker.color.a = " + _imageHitMarker.color.a);
            if (_colorAvalue != 0)
            {
                _colorAvalue = 0;
                _imageHitMarker.color = _colorHitmarker;
            }
            _playerProfilInGame.PlayerInGame.SetHit(false);
            _afficherHitMarker = true;
        }

        if(_afficherHitMarker)
        {
            _colorAvalue += Time.deltaTime * _coefTimeHitA;
            _imageHitMarker.color = _colorHitmarker - new Color(0, 0, 0, _colorAvalue);

            if(_colorAvalue <= 0)
            {
                _goHitMarker.SetActive(false);
                _afficherHitMarker = false;
            }
        }
    }

    public void AjouterUnPlayerTestNoTeam(string pseudo)
    {
        GameObject newLigne = Instantiate(_prefabTextScore, _scrollNoTeam.content.transform);
        newLigne.GetComponent<TextMeshProUGUI>().text = pseudo;
    }

    public void AjouterUnPlayerTestNoTeam(PlayerInGame pig)
    {
        GameObject newLigne = Instantiate(_prefabTextScore, _scrollNoTeam.content.transform);
        newLigne.GetComponent<TextMeshProUGUI>().text = pig.PlayerProfil.Pseudo + " / " + pig.ScoreTotal;
    }

    public GameObject PanelScore { get => _panelScore; set => _panelScore = value; }
    public GameObject PanelScoreTeam { get => _panelScoreTeam; set => _panelScoreTeam = value; }
    public GameObject PanelScoreNoTeam { get => _panelScoreNoTeam; set => _panelScoreNoTeam = value; }
}
