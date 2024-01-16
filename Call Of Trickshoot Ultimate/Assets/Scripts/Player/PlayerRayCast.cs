using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector3 _hitPointWorld;
    [SerializeField] private Transform _hitTransform;


    private void FixedUpdate()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(_camera.transform.position, _camera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, _layerMask))
        {
            Debug.DrawRay(_camera.transform.position, _camera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.cyan);
            _hitPointWorld = hit.point;
            if (!_hitTransform.gameObject.activeSelf)
            {
                _hitTransform.gameObject.SetActive(true);
            }
            _hitTransform.position = _hitPointWorld;
        }
        else
        {
            Debug.DrawRay(_camera.transform.position, _camera.transform.TransformDirection(Vector3.forward) * 1000, Color.black);
            _hitPointWorld = Vector3.zero;
            _hitTransform.position = _hitPointWorld;
            if (_hitTransform.gameObject.activeSelf)
            {
                _hitTransform.gameObject.SetActive(false);
            }
        }
    }

    public Vector3 HitPointWorld { get => _hitPointWorld; set => _hitPointWorld = value; }
}