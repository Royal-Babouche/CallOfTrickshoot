using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private PlayerInGame _playerInGame;
    [SerializeField] private GameParametreData _gameParametreData;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _masse, _force, _longeurTravers, _longueurTraversTotal;
    [SerializeField] private int _nbTravers;
    [SerializeField] private Vector3 _velocity, _newPosBullet, _posLongueur1, _posLongueur2;

    private void FixedUpdate()
    {
        // Kinematik
/*        _velocity = transform.forward * _force;
        _newPosBullet = transform.position + _velocity * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_newPosBullet);*/

        // No Kinematik
        //_rigidbody.velocity = transform.forward * _force;
        //_rigidbody.AddForce(new Vector3(0, -9.81f * _masse * Time.deltaTime, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(this.name + " Entre dans " + other.name + " layer = " + other.gameObject.layer);

        if (other.gameObject.layer != 31)
        {
            if (_nbTravers == 0)
            {
                _longueurTraversTotal = 0;
            }
        }
        _posLongueur1 = transform.position;

        // Player
        if (other.gameObject.layer == 10)
        {
            Debug.Log("Player -> Doit le tuer et le faire réaparaitre ou non en fonction du mode de la partie");
            //JouSonImpact();
            //other.transform.parent.parent.GetComponentInChildren<Entity>().PerdVie(_degat.StatActuel);
            _playerInGame.SetHit(true);
        }
        // Esclave
        if (other.gameObject.layer == 11)
        {
            Debug.Log("Esclave -> Doit le tuer et le faire réaparaitre ou non en fonction du mode de la partie");
            _playerInGame.ScoreTotal += 50;
            other.gameObject.SetActive(false);
            //JouSonImpact();
            //other.transform.parent.parent.GetComponentInChildren<Entity>().PerdVie(_degat.StatActuel);
            // Afficher Hit Marker
            _playerInGame.SetHit(true);
        }
        // Collision Surface
        if (other.gameObject.layer == 30)
        {
            Debug.Log("Collision Surface");
            //JouSonImpact();
            if (!_gameParametreData.TraversInfini)
            {
                this.gameObject.SetActive(false);
            }
        }

        // Dead Zone
        if (other.gameObject.layer == 31)
        {
            Debug.Log("Dead Zone");
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(this.name + " Exit dans " + other.name + " layer = " + other.gameObject.layer);
        _nbTravers++;
        _posLongueur2 = transform.position;
        _longeurTravers = Vector3.Distance(_posLongueur1, _posLongueur2);
        _longueurTraversTotal += _longeurTravers;
    }

    public void SetPlayerInGame(PlayerInGame playerInGame)
    {
        _playerInGame = playerInGame;
    }

    public void InitBullet(float force)
    {
        _force = force;
        _nbTravers = 0;
        _longeurTravers = 0;
        _longueurTraversTotal = 0;
        _posLongueur1 = Vector3.zero;
        _posLongueur2 = Vector3.zero;
        AddForce();
    }

    public void AddForce()
    {
        _rigidbody.velocity = transform.forward * _force;
    }
}
