using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    [SerializeField] private string _playerName;
    [SerializeField] private bool _groundCheck;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.transform.name + " touche " + other.gameObject.name);
        if (other.gameObject.layer == 10 || other.gameObject.layer == 11 || other.gameObject.layer == 30)
        {
            if (other.gameObject.name != _playerName)
            {
                _groundCheck = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 11 || other.gameObject.layer == 30)
        {
            if (other.gameObject.name != _playerName)
            {
                _groundCheck = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 11 || other.gameObject.layer == 30)
        {
            if (other.gameObject.name != _playerName)
            {
                _groundCheck = false;
            }
        }
    }

    public string PlayerName { get => _playerName; set => _playerName = value; }
    public bool GroundCheck { get => _groundCheck; set => _groundCheck = value; }
}
